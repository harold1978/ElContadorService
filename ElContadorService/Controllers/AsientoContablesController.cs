using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElContadorService.Data;
using ElContadorService.Models;

namespace ElContadorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoContablesController : ControllerBase
    {
        private readonly ElContador2025V2Context _context;

        public AsientoContablesController(ElContador2025V2Context context)
        {
            _context = context;
        }

        // GET: api/AsientoContables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsientoContable>>> GetAsientoContables()
        {
            return await _context.AsientoContables.Include(d=>d.DetalleAsientoContables).ToListAsync();
        }

        // GET: api/AsientoContables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsientoContable>> GetAsientoContable(int id)
        {
            var asientoContable = await _context.AsientoContables.FindAsync(id);

            if (asientoContable == null)
            {
                return NotFound();
            }

            return asientoContable;
        }

        // PUT: api/AsientoContables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsientoContable(int id, AsientoContable asientoContable)
        {
            if (id != asientoContable.Id)
            {
                return BadRequest();
            }

            _context.Entry(asientoContable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoContableExists(id))
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

        // POST: api/AsientoContables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AsientoContable>> PostAsientoContable(AsientoContable asientoContable)
        {
            _context.AsientoContables.Add(asientoContable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsientoContable", new { id = asientoContable.Id }, asientoContable);
        }

        // DELETE: api/AsientoContables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsientoContable(int id)
        {
            var asientoContable = await _context.AsientoContables.FindAsync(id);
            if (asientoContable == null)
            {
                return NotFound();
            }

            _context.AsientoContables.Remove(asientoContable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsientoContableExists(int id)
        {
            return _context.AsientoContables.Any(e => e.Id == id);
        }
    }
}
