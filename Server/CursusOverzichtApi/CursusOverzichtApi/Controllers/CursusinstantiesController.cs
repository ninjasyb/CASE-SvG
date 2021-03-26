using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursusOverzichtApi.Models;
using System.Text;
using CursusOverzichtApi.Services;

namespace CursusOverzichtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusinstantiesController : ControllerBase
    {
        private readonly CursusContext _context;
        UploadResult uploadResult = new UploadResult();


        public CursusinstantiesController(CursusContext context)
        {
            _context = context;
        }

        // GET: api/Cursusinstanties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursusinstantie>>> Getcursusinstanties()
        {
            return await _context.cursusinstanties.ToListAsync();
        }

        // GET: api/Cursusinstanties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursusinstantie>> GetCursusinstantie(int id)
        {
            var cursusinstantie = await _context.cursusinstanties.FindAsync(id);

            if (cursusinstantie == null)
            {
                return NotFound();
            }

            return cursusinstantie;
        }

        // PUT: api/Cursusinstanties/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursusinstantie(int id, Cursusinstantie cursusinstantie)
        {
            if (id != cursusinstantie.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursusinstantie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursusinstantieExists(id))
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

        // POST: api/Cursusinstanties
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cursusinstantie>> PostCursusinstantie(Cursusinstantie cursusinstantie)
        {
            _context.cursusinstanties.Add(cursusinstantie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursusinstantie", new { id = cursusinstantie.Id }, cursusinstantie);
        }

        // DELETE: api/Cursusinstanties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cursusinstantie>> DeleteCursusinstantie(int id)
        {
            var cursusinstantie = await _context.cursusinstanties.FindAsync(id);
            if (cursusinstantie == null)
            {
                return NotFound();
            }

            _context.cursusinstanties.Remove(cursusinstantie);
            await _context.SaveChangesAsync();

            return cursusinstantie;
        }

        private bool CursusinstantieExists(int id)
        {
            return _context.cursusinstanties.Any(e => e.Id == id);
        }

        [HttpPost("fileUpload")]
        [ActionName(nameof(getInputFile))]
        public async Task<ActionResult> getInputFile(UploadFile uploadFile) {
            Console.WriteLine(uploadFile.Content);
            string[] paragraph = uploadFile.Content.Split("\n\n");
            foreach (var p in paragraph) {
                try {
                    await CheckParagraph(p);
                } catch (ArgumentException) {
                    return ValidationProblem();
                }
            }
            return Ok(uploadResult);
        }

        private async Task CheckParagraph(string paragraph) {
            CheckFile cf = new CheckFile();
            string[] line = paragraph.Split("\n");
            //check of Cursus al bestaat
            if (!_context.cursussen.Any(e => e.CursusCode.Equals(cf.ExtractCode(line[1])))) {
                    Cursus cursus = new Cursus(cf.ExtractTitle(line[0]), cf.ExtractCode(line[1]), cf.ExtractDuur(line[2]));
                    await addCursus(cursus);
            } else {
                int id = _context.cursussen.SingleOrDefault(c => c.CursusCode == cf.ExtractCode(line[1])).Id;
                DateTime startDatum = cf.ExtractStartDatum(line[3]);
                Cursusinstantie cursusinstantie = new Cursusinstantie(id, startDatum);
                await addCursusInstantie(cursusinstantie);
            }
        }
        private async Task addCursusInstantie(Cursusinstantie cursusinstantie) {
            uploadResult.NewInstanties += 1;
            _context.cursusinstanties.Add(cursusinstantie);
            await _context.SaveChangesAsync();
        }

        private async Task addCursus(Cursus cursus) {
            uploadResult.NewCursussen += 1;
            _context.cursussen.Add(cursus);
            await _context.SaveChangesAsync();
        }
    }
}
