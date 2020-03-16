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
    public class ConfirmationReceptionsController : ControllerBase
    {
        private readonly DataContext _context;

        public ConfirmationReceptionsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ConfirmationReceptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfirmationReception>>> GetConfirmationReceptions()
        {
            return await _context.ConfirmationReceptions.ToListAsync();
        }

        // GET: api/ConfirmationReceptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfirmationReception>> GetConfirmationReception(int id)
        {
            var confirmationReception = await _context.ConfirmationReceptions.FindAsync(id);

            if (confirmationReception == null)
            {
                return NotFound();
            }

            return confirmationReception;
        }

        // PUT: api/ConfirmationReceptions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfirmationReception(int id, ConfirmationReception confirmationReception)
        {
            if (id != confirmationReception.Id)
            {
                return BadRequest();
            }

            _context.Entry(confirmationReception).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmationReceptionExists(id))
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

        // POST: api/ConfirmationReceptions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ConfirmationReception>> PostConfirmationReception(ConfirmationReception confirmationReception)
        {
            _context.ConfirmationReceptions.Add(confirmationReception);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfirmationReception", new { id = confirmationReception.Id }, confirmationReception);
        }

        // DELETE: api/ConfirmationReceptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConfirmationReception>> DeleteConfirmationReception(int id)
        {
            var confirmationReception = await _context.ConfirmationReceptions.FindAsync(id);
            if (confirmationReception == null)
            {
                return NotFound();
            }

            _context.ConfirmationReceptions.Remove(confirmationReception);
            await _context.SaveChangesAsync();

            return confirmationReception;
        }

        private bool ConfirmationReceptionExists(int id)
        {
            return _context.ConfirmationReceptions.Any(e => e.Id == id);
        }
    }
}
