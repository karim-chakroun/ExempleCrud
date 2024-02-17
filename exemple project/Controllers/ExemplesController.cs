using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exemple_project.Data;
using exemple_project.Models;

namespace exemple_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemplesController : ControllerBase
    {
        private readonly exemple_projectContext _context;

        public ExemplesController(exemple_projectContext context)
        {
            _context = context;
        }

        // GET: api/Exemples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exemple>>> GetExemple()
        {
          if (_context.Exemple == null)
          {
              return NotFound();
          }
            return await _context.Exemple.ToListAsync();
        }

        // GET: api/Exemples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exemple>> GetExemple(int id)
        {
          if (_context.Exemple == null)
          {
              return NotFound();
          }
            var exemple = await _context.Exemple.FindAsync(id);

            if (exemple == null)
            {
                return NotFound();
            }

            return exemple;
        }

        // PUT: api/Exemples/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExemple(int id, Exemple exemple)
        {
            if (id != exemple.id)
            {
                return BadRequest();
            }

            _context.Entry(exemple).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExempleExists(id))
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

        // POST: api/Exemples
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exemple>> PostExemple(Exemple exemple)
        {
          if (_context.Exemple == null)
          {
              return Problem("Entity set 'exemple_projectContext.Exemple'  is null.");
          }
            _context.Exemple.Add(exemple);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExemple", new { id = exemple.id }, exemple);
        }

        // DELETE: api/Exemples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExemple(int id)
        {
            if (_context.Exemple == null)
            {
                return NotFound();
            }
            var exemple = await _context.Exemple.FindAsync(id);
            if (exemple == null)
            {
                return NotFound();
            }

            _context.Exemple.Remove(exemple);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExempleExists(int id)
        {
            return (_context.Exemple?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
