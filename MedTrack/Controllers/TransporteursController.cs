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
    public class TransporteursController : ControllerBase
    {
        private readonly DataContext _context;

        public TransporteursController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Transporteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transporteur>>> GetTransporteurs()
        {
            return await _context.Transporteurs.ToListAsync();
        }

        // GET: api/Transporteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transporteur>> GetTransporteur(int id)
        {
            var transporteur = await _context.Transporteurs.FindAsync(id);

            if (transporteur == null)
            {
                return NotFound();
            }

            return transporteur;
        }

        // PUT: api/Transporteurs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransporteur(int id, Transporteur transporteur)
        {
            if (id != transporteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(transporteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteurExists(id))
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

        // POST: api/Transporteurs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Transporteur>> PostTransporteur(Transporteur transporteur)
        {
            _context.Transporteurs.Add(transporteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransporteur", new { id = transporteur.Id }, transporteur);
        }

        // DELETE: api/Transporteurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transporteur>> DeleteTransporteur(int id)
        {
            var transporteur = await _context.Transporteurs.FindAsync(id);
            if (transporteur == null)
            {
                return NotFound();
            }

            _context.Transporteurs.Remove(transporteur);
            await _context.SaveChangesAsync();

            return transporteur;
        }

        private bool TransporteurExists(int id)
        {
            return _context.Transporteurs.Any(e => e.Id == id);
        }
    }
}
