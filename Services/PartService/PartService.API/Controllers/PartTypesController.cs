using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartService.DataLayer.DataAccess;
using PartService.DataLayer.Models;

namespace PartService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartTypesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PartTypesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PartTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartType>>> GetPartType()
        {
            return await _context.PartType.ToListAsync();
        }

        // GET: api/PartTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartType>> GetPartType(int id)
        {
            var partType = await _context.PartType.FindAsync(id);

            if (partType == null)
            {
                return NotFound();
            }

            return partType;
        }

        // PUT: api/PartTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartType(int id, PartType partType)
        {
            if (id != partType.Id)
            {
                return BadRequest();
            }

            _context.Entry(partType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartTypeExists(id))
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

        // POST: api/PartTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartType>> PostPartType(PartType partType)
        {
            _context.PartType.Add(partType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartType", new { id = partType.Id }, partType);
        }

        // DELETE: api/PartTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartType(int id)
        {
            var partType = await _context.PartType.FindAsync(id);
            if (partType == null)
            {
                return NotFound();
            }

            _context.PartType.Remove(partType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartTypeExists(int id)
        {
            return _context.PartType.Any(e => e.Id == id);
        }
    }
}
