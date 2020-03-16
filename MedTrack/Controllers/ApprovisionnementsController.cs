using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedTrack.Data;
using MedTrack.Models;

namespace MedTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovisionnementsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApprovisionnementsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Approvisionnements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Approvisionnement>>> GetApprovisionnements()
        {
            return await _context.Approvisionnements.ToListAsync();
        }

        // GET: api/Approvisionnements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Approvisionnement>> GetApprovisionnement(int id)
        {
            var approvisionnement = await _context.Approvisionnements.FindAsync(id);

            if (approvisionnement == null)
            {
                return NotFound();
            }

            return approvisionnement;
        }

        // PUT: api/Approvisionnements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApprovisionnement(int id, Approvisionnement approvisionnement)
        {
            if (id != approvisionnement.Id)
            {
                return BadRequest();
            }

            _context.Entry(approvisionnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovisionnementExists(id))
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

        // POST: api/Approvisionnements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Approvisionnement>> PostApprovisionnement(Approvisionnement approvisionnement)
        {
            _context.Approvisionnements.Add(approvisionnement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApprovisionnement", new { id = approvisionnement.Id }, approvisionnement);
        }

        // DELETE: api/Approvisionnements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Approvisionnement>> DeleteApprovisionnement(int id)
        {
            var approvisionnement = await _context.Approvisionnements.FindAsync(id);
            if (approvisionnement == null)
            {
                return NotFound();
            }

            _context.Approvisionnements.Remove(approvisionnement);
            await _context.SaveChangesAsync();

            return approvisionnement;
        }

        private bool ApprovisionnementExists(int id)
        {
            return _context.Approvisionnements.Any(e => e.Id == id);
        }
    }
}
