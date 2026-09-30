using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pasta_API.Data;
using Pasta_API.Models;

namespace Pasta_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Armas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arma>>> GetAll()
        {
            var armas = await _context.Armas.ToListAsync();

            return Ok(armas);
        }

        // GET: api/Armas/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Arma>> GetById(int id)
        {
            var arma = await _context.Armas.FindAsync(id);

            if (arma == null)
            {
                return NotFound();
            }

            return Ok(arma);
        }

        // POST: api/Armas
        [HttpPost]
        public async Task<ActionResult<Arma>> Post(Arma arma)
        {
            _context.Armas.Add(arma);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = arma.Id },
                arma
            );
        }

        // PUT: api/Armas/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Arma arma)
        {
            if (id != arma.Id)
            {
                return BadRequest();
            }

            var armaExiste = await _context.Armas.FindAsync(id);

            if (armaExiste == null)
            {
                return NotFound();
            }

            armaExiste.Nome = arma.Nome;
            armaExiste.Dano = arma.Dano;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Armas/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var arma = await _context.Armas.FindAsync(id);

            if (arma == null)
            {
                return NotFound();
            }

            _context.Armas.Remove(arma);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
