using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedTrack.Data;
using MedTrack.Models;

namespace MedTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributeursController : ControllerBase
    {
        private readonly DataContext _context;

        public DistributeursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Distributeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributeur>>> GetDistributeurs()
        {
            return await _context.Distributeurs.ToListAsync();
        }

        // GET: api/Distributeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distributeur>> GetDistributeur(int id)
        {
            var distributeur = await _context.Distributeurs.FindAsync(id);

            if (distributeur == null)
            {
                return NotFound();
            }

            return distributeur;
        }

        // PUT: api/Distributeurs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributeur(int id, Distributeur distributeur)
        {
            if (id != distributeur.Id)
            {
                return BadRequest();
            }

            _context.Entry(distributeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributeurExists(id))
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

        // POST: api/Distributeurs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Distributeur>> PostDistributeur(Distributeur distributeur)
        {
            _context.Distributeurs.Add(distributeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistributeur", new { id = distributeur.Id }, distributeur);
        }

        // DELETE: api/Distributeurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Distributeur>> DeleteDistributeur(int id)
        {
            var distributeur = await _context.Distributeurs.FindAsync(id);
            if (distributeur == null)
            {
                return NotFound();
            }

            _context.Distributeurs.Remove(distributeur);
            await _context.SaveChangesAsync();

            return distributeur;
        }

        private bool DistributeurExists(int id)
        {
            return _context.Distributeurs.Any(e => e.Id == id);
        }
    }
}
