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
    public class CuentaContablesController : ControllerBase
    {
        private readonly ElContador2025V2Context _context;

        public CuentaContablesController(ElContador2025V2Context context)
        {
            _context = context;
        }

        // GET: api/CuentaContables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuentaContable>>> GetCuentaContables()
        {
            return await _context.CuentaContables.ToListAsync();
        }

        // GET: api/CuentaContables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaContable>> GetCuentaContable(int id)
        {
            var cuentaContable = await _context.CuentaContables.FindAsync(id);

            if (cuentaContable == null)
            {
                return NotFound();
            }

            return cuentaContable;
        }

        // PUT: api/CuentaContables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentaContable(int id, CuentaContable cuentaContable)
        {
            if (id != cuentaContable.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentaContable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaContableExists(id))
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

        // POST: api/CuentaContables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CuentaContable>> PostCuentaContable(CuentaContable cuentaContable)
        {
            _context.CuentaContables.Add(cuentaContable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentaContable", new { id = cuentaContable.Id }, cuentaContable);
        }

        // DELETE: api/CuentaContables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentaContable(int id)
        {
            var cuentaContable = await _context.CuentaContables.FindAsync(id);
            if (cuentaContable == null)
            {
                return NotFound();
            }

            _context.CuentaContables.Remove(cuentaContable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentaContableExists(int id)
        {
            return _context.CuentaContables.Any(e => e.Id == id);
        }
    }
}
