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
    public class PrescribeResourceController : ControllerBase
    {
        private readonly KooshDarooContext _context;

        public PrescribeResourceController(KooshDarooContext context)
        {
            _context = context;
        }

        // GET: api/PrescribeResource
        [HttpGet]
        public IEnumerable<PrescribeResource> GetPrescribeResource()
        {
            return _context.PrescribeResource;
        }

        // GET: api/PrescribeResource/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescribeResource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PrescribeResource = await _context.PrescribeResource.FindAsync(id);

            if (PrescribeResource == null)
            {
                return NotFound();
            }

            return Ok(PrescribeResource);
        }

        [HttpGet("Id/{id}")]
        public IEnumerable<PrescribeResource> GetPrescribes(int id)
        {
            var PrescribeResource = _context.PrescribeResource.Where(f => f.id == id);

            return PrescribeResource;
        }
        // PUT: api/PrescribeResource/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescribeResource([FromRoute] int id, [FromBody] PrescribeResource prescribeResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prescribeResource.id)
            {
                return BadRequest();
            }

            //Set DateOf AcceptS
            if (prescribeResource.MemberAccepted)
                prescribeResource.MemberAcceptDateOf = DateTime.Now;

            _context.Entry(prescribeResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescribeResourceExists(id))
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

        // POST: api/PrescribeResource
        [HttpPost]
        public async Task<IActionResult> PostPrescribeResource([FromBody] PrescribeResource prescribeResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int count = _context.PrescribeResource.Where(f => f.PharmacyId == prescribeResource.PharmacyId & f.PrescribeId == prescribeResource.PrescribeId).Count();
            if (count > 0)
                return BadRequest(ModelState);

            prescribeResource.PharmacyAcceptDateOf = DateTime.Now;
            prescribeResource.MemberAcceptDateOf = DateTime.FromOADate(0);
            _context.PrescribeResource.Add(prescribeResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescribeResource", new { id = prescribeResource.id }, prescribeResource);
        }

        // DELETE: api/PrescribeResource/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescribeResource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PrescribeResource = await _context.PrescribeResource.FindAsync(id);
            if (PrescribeResource == null)
            {
                return NotFound();
            }

            _context.PrescribeResource.Remove(PrescribeResource);
            await _context.SaveChangesAsync();

            return Ok(PrescribeResource);
        }

        private bool PrescribeResourceExists(int id)
        {
            return _context.PrescribeResource.Any(e => e.id == id);
        }
    }
}