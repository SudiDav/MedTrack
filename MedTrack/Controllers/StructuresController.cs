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
    public class StructuresController : ControllerBase
    {
        private readonly DataContext _context;

        public StructuresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Structures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Structure>>> GetStructures()
        {
            return await _context.Structures.ToListAsync();
        }

        // GET: api/Structures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Structure>> GetStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);

            if (structure == null)
            {
                return NotFound();
            }

            return structure;
        }

        // PUT: api/Structures/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructure(int id, Structure structure)
        {
            if (id != structure.Id)
            {
                return BadRequest();
            }

            _context.Entry(structure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureExists(id))
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

        // POST: api/Structures
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Structure>> PostStructure(Structure structure)
        {
            _context.Structures.Add(structure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStructure", new { id = structure.Id }, structure);
        }

        // DELETE: api/Structures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Structure>> DeleteStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }

            _context.Structures.Remove(structure);
            await _context.SaveChangesAsync();

            return structure;
        }

        private bool StructureExists(int id)
        {
            return _context.Structures.Any(e => e.Id == id);
        }
    }
}
