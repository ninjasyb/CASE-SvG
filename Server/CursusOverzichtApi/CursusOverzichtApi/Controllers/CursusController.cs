using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursusOverzichtApi.Models;

namespace CursusOverzichtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusController : ControllerBase
    {
        private readonly CursusContext _context;

        public CursusController(CursusContext context)
        {
            _context = context;
        }

        // GET: api/Cursus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursus>>> Getcursussen()
        {
            return await _context.cursussen.ToListAsync();
        }

        // GET: api/Cursus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursus>> GetCursus(int id)
        {
            var cursus = await _context.cursussen.FindAsync(id);

            if (cursus == null)
            {
                return NotFound();
            }

            return cursus;
        }

        // PUT: api/Cursus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursus(int id, Cursus cursus)
        {
            if (id != cursus.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusExists(id))
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

        // POST: api/Cursus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cursus>> PostCursus(Cursus cursus)
        {
            _context.cursussen.Add(cursus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursus", new { id = cursus.Id }, cursus);
        }

        // DELETE: api/Cursus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cursus>> DeleteCursus(int id)
        {
            var cursus = await _context.cursussen.FindAsync(id);
            if (cursus == null)
            {
                return NotFound();
            }

            _context.cursussen.Remove(cursus);
            await _context.SaveChangesAsync();

            return cursus;
        }

        private bool CursusExists(int id)
        {
            return _context.cursussen.Any(e => e.Id == id);
        }
    }
}
