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
    public class PharmacyConnectionController : ControllerBase
    {
        private readonly KooshDarooContext _context;

        public PharmacyConnectionController(KooshDarooContext context)
        {
            _context = context;
        }

        // GET: api/PharmacyConnection
        [HttpGet]
        public IEnumerable<PharmacyConnection> GetPharmacyConnection()
        {
            return _context.PharmacyConnection;
        }

        // GET: api/PharmacyConnection/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacyConnection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacyConnection = await _context.PharmacyConnection.FindAsync(id);

            if (pharmacyConnection == null)
            {
                return NotFound();
            }

            return Ok(pharmacyConnection);
        }

        // PUT: api/PharmacyConnection/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacyConnection([FromRoute] int id, [FromBody] PharmacyConnection pharmacyConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacyConnection.id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacyConnection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyConnectionExists(id))
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

        // POST: api/PharmacyConnection
        [HttpPost]
        public async Task<IActionResult> PostPharmacyConnection([FromBody] PharmacyConnection pharmacyConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PharmacyConnection.Add(pharmacyConnection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacyConnection", new { id = pharmacyConnection.id }, pharmacyConnection);
        }

        // DELETE: api/PharmacyConnection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacyConnection([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pharmacyConnection = await _context.PharmacyConnection.FindAsync(id);
            if (pharmacyConnection == null)
            {
                return NotFound();
            }

            _context.PharmacyConnection.Remove(pharmacyConnection);
            await _context.SaveChangesAsync();

            return Ok(pharmacyConnection);
        }

        private bool PharmacyConnectionExists(int id)
        {
            return _context.PharmacyConnection.Any(e => e.id == id);
        }
    }
}