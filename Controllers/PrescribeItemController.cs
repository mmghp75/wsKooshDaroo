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
    public class PrescribeItemController : ControllerBase
    {
        private readonly KooshDarooContext _context;

        public PrescribeItemController(KooshDarooContext context)
        {
            _context = context;
        }

        // GET: api/PrescribeItem
        [HttpGet]
        public IEnumerable<PrescribeItem> GetPrescribeItem()
        {
            return _context.PrescribeItem;
        }

        // GET: api/PrescribeItem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescribeItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescribeItem = await _context.PrescribeItem.FindAsync(id);

            if (prescribeItem == null)
            {
                return NotFound();
            }

            return Ok(prescribeItem);
        }

        [HttpGet("PrescribeId/{prescribeId}")]
        public IQueryable<PrescribeItem> GetPrescribeItemByPrescribeId(int prescribeId)
        {
            return _context.PrescribeItem.Where(f => f.PrescribeId == prescribeId);
        }


        // PUT: api/PrescribeItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescribeItem([FromRoute] int id, [FromBody] PrescribeItem prescribeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prescribeItem.id)
            {
                return BadRequest();
            }

            _context.Entry(prescribeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescribeItemExists(id))
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

        // POST: api/PrescribeItem
        [HttpPost]
        public async Task<IActionResult> PostPrescribeItem([FromBody] PrescribeItem prescribeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PrescribeItem.Add(prescribeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescribeItem", new { id = prescribeItem.id }, prescribeItem);
        }

        // DELETE: api/PrescribeItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescribeItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prescribeItem = await _context.PrescribeItem.FindAsync(id);
            if (prescribeItem == null)
            {
                return NotFound();
            }

            _context.PrescribeItem.Remove(prescribeItem);
            await _context.SaveChangesAsync();

            return Ok(prescribeItem);
        }

        private bool PrescribeItemExists(int id)
        {
            return _context.PrescribeItem.Any(e => e.id == id);
        }
    }
}