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
    public class DepotsController : ControllerBase
    {
        private readonly DataContext _context;

        public DepotsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Depots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetDepots()
        {
            return await _context.Depots.ToListAsync();
        }

        // GET: api/Depots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetDepot(int id)
        {
            var depot = await _context.Depots.FindAsync(id);

            if (depot == null)
            {
                return NotFound();
            }

            return depot;
        }

        // PUT: api/Depots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepot(int id, Depot depot)
        {
            if (id != depot.Id)
            {
                return BadRequest();
            }

            _context.Entry(depot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepotExists(id))
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

        // POST: api/Depots
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Depot>> PostDepot(Depot depot)
        {
            _context.Depots.Add(depot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepot", new { id = depot.Id }, depot);
        }

        // DELETE: api/Depots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Depot>> DeleteDepot(int id)
        {
            var depot = await _context.Depots.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }

            _context.Depots.Remove(depot);
            await _context.SaveChangesAsync();

            return depot;
        }

        private bool DepotExists(int id)
        {
            return _context.Depots.Any(e => e.Id == id);
        }
    }
}
