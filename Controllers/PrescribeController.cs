using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wsKooshDaroo.Data;
using wsKooshDaroo.Hubs;
using wsKooshDaroo.Models;

namespace wsKooshDaroo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescribeController : ControllerBase
    {
        private readonly KooshDarooContext _context;

        public PrescribeController(KooshDarooContext context)
        {
            _context = context;
        }

        // GET: api/Prescribe
        [HttpGet]
        public IEnumerable<Prescribe> GetPrescribe()
        {
            return _context.Prescribe;
        }
        [HttpGet("Id/{id}")]
        public IEnumerable<Prescribe> GetPrescribe(int id)
        {
            var Prescribe =  _context.Prescribe.Where(f => f.id == id);

            return Prescribe;
        }

        // GET: api/Prescribe/PhoneNo/09125555555/DateOf/20190101 8:30:34.456
        [HttpGet("PhoneNo/{phoneNo}/DateOf/{dateOf}")]
        public IQueryable<Prescribe> GetPrescribeByPhoneNoAndDateOf(string phoneNo, DateTime dateOf)
        {
            return _context.Prescribe.Where(f => f.PhoneNo == phoneNo & f.DateOf == dateOf);
        }
        // GET: api/Prescribe/PhoneNo/09125555555/DateOf/20190101 8:30:34.456
        [HttpGet("DateOf/{dateOf}/X/{X}/Y/{Y}")]
        public IQueryable<Prescribe> GetPrescribeByDateOfXY(DateTime dateOf, double X, double Y)
        {
            var result = _context.Prescribe.Where(f => f.DateOf == dateOf & f.X == X & f.Y == Y);
            return result;
        }
        [HttpGet("Days/{days}")]
        public IQueryable<Prescribe> GetUnresponcedPrescribe(int days)
        {
            var excludeIDS = _context.PrescribeResource.Where(f => f.MemberAccepted).Select(f => f.PrescribeId).ToList<int>();
            var result = _context.Prescribe.Where(f => f.DateOf.AddDays(days) >= DateTime.Now & !excludeIDS.Contains(f.id));
            foreach (Prescribe r in result)
                r.Prescription = null;

            return result;
        }
        [HttpGet("PhoneNo/{phoneNo}/Days/{days}")]
        public IQueryable<Prescribe> GetAcceptedByPharmacyPrescribe(string phoneNo, int days)
        {
            var pharmacy = _context.Pharmacy.Where(f => f.PhoneNo == phoneNo).FirstOrDefault();
            if (pharmacy == null)
                return null;
            var prescribeIDs = _context.PrescribeResource.Where(f => f.PharmacyId == pharmacy.id).Select(f => f.PrescribeId).ToList<int>();
            var result = _context.Prescribe.Where(f => prescribeIDs.Contains(f.id) & f.DateOf.AddDays(days) >= DateTime.Now);
           
            foreach (Prescribe r in result)
                r.Prescription = null;

            return result;
        }
        //// GET: api/Prescribe/Id/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPrescribe([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var Prescribe = await _context.Prescribe.FindAsync(id);

        //    if (Prescribe == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(Prescribe);
        //}

        // PUT: api/Prescribe/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescribe([FromRoute] int id, [FromBody] Prescribe Prescribe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Prescribe.id)
            {
                return BadRequest();
            }

            _context.Entry(Prescribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescribeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Prescribe
        [HttpPost]
        public async Task<IActionResult> PostPrescribe([FromBody] Prescribe prescribe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prescribe _lastprescribe = _context.Prescribe.Where(f => f.PhoneNo == prescribe.PhoneNo).OrderBy(f => f.DateOf).FirstOrDefault();
            if (_lastprescribe != null)
                if (DateTime.Now.ToOADate() - _lastprescribe.DateOf.ToOADate() < 0.5)
                    return BadRequest(ModelState);

            prescribe.DateOf = DateTime.Now;
            _context.Prescribe.Add(prescribe);
            await _context.SaveChangesAsync();

            prescribe.Prescription = new byte[0];
            IActionResult result = CreatedAtAction("GetPrescribe", new { id = prescribe.id }, prescribe);
            return result;
        }

        // DELETE: api/Prescribe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescribe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescribe = await _context.Prescribe.FindAsync(id);
            if (prescribe == null)
            {
                return NotFound();
            }

            _context.Prescribe.Remove(prescribe);
            await _context.SaveChangesAsync();

            return Ok(prescribe.id);
        }

        private bool PrescribeExists(int id)
        {
            return _context.Prescribe.Any(e => e.id == id);
        }
    }
}