using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wsKooshDaroo.Data;
using wsKooshDaroo.Models;

namespace wsKooshDaroo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly KooshDarooContext _context;

        public PharmacyController(KooshDarooContext context)
        {
            _context = context;
        }

        // GET: api/Pharmacy
        [HttpGet]
        public IEnumerable<Pharmacy> GetPharmacy()
        {
            return _context.Pharmacy;
        }

        // GET: api/Pharmacy/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Pharmacy = await _context.Pharmacy.FindAsync(id);

            if (Pharmacy == null)
            {
                return NotFound();
            }

            return Ok(Pharmacy);
        }

        // GET: api/Pharmacy/PhoneNo/09125555555
        [HttpGet("PhoneNo/{phoneno}")]
        public IQueryable<Pharmacy> GetPharmacyByPhoneNo(string phoneno)
        {
            return _context.Pharmacy.Where(f => f.PhoneNo == phoneno);
        }

        // PUT: api/Pharmacy/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy([FromRoute] int id, [FromBody] Pharmacy Pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Pharmacy.id)
            {
                return BadRequest();
            }

            _context.Entry(Pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
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

        [HttpGet("Id/{id}")]
        public IEnumerable<Pharmacy> GetPrescribes(int id)
        {
            var Pharmacy = _context.Pharmacy.Where(f => f.id == id);

            return Pharmacy;
        }

        // POST: api/Pharmacy
        [HttpPost]
        public async Task<IActionResult> PostPharmacy([FromBody] Pharmacy Pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pharmacy.Add(Pharmacy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacy", new { id = Pharmacy.id }, Pharmacy);
        }

        // DELETE: api/Pharmacy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Pharmacy = await _context.Pharmacy.FindAsync(id);
            if (Pharmacy == null)
            {
                return NotFound();
            }

            _context.Pharmacy.Remove(Pharmacy);
            await _context.SaveChangesAsync();

            return Ok(Pharmacy);
        }

        private bool PharmacyExists(int id)
        {
            return _context.Pharmacy.Any(e => e.id == id);
        }
    }
}