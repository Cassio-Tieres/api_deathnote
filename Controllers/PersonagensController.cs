using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_death_note.Models;

namespace api_death_note.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private readonly PersonagemContext _context;

        public PersonagensController(PersonagemContext context)
        {
            _context = context;
        }

        // GET: api/Personagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagens>>> GetPersonagens()
        {
          if (_context.Personagens == null)
          {
              return NotFound();
          }
            return await _context.Personagens.ToListAsync();
        }

        // GET: api/Personagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personagens>> GetPersonagens(long id)
        {
          if (_context.Personagens == null)
          {
              return NotFound();
          }
            var personagens = await _context.Personagens.FindAsync(id);

            if (personagens == null)
            {
                return NotFound();
            }

            return personagens;
        }

        // PUT: api/Personagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonagens(long id, Personagens personagens)
        {
            if (id != personagens.Id)
            {
                return BadRequest();
            }

            _context.Entry(personagens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonagensExists(id))
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

        // POST: api/Personagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personagens>> PostPersonagens(Personagens personagens)
        {
          if (_context.Personagens == null)
          {
              return Problem("Entity set 'PersonagemContext.Personagens'  is null.");
          }
            _context.Personagens.Add(personagens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonagens", new { id = personagens.Id }, personagens);
        }

        // DELETE: api/Personagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagens(long id)
        {
            if (_context.Personagens == null)
            {
                return NotFound();
            }
            var personagens = await _context.Personagens.FindAsync(id);
            if (personagens == null)
            {
                return NotFound();
            }

            _context.Personagens.Remove(personagens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonagensExists(long id)
        {
            return (_context.Personagens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
