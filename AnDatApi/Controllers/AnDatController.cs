using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnDatApi.Models;

namespace AnDatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnDatController : ControllerBase
    {
        private readonly AnDatContext _context;

        public AnDatController(AnDatContext context)
        {
            _context = context;
        }

        // GET: api/AnDat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnDatItem>>> GetAnDatItems()
        {
            return await _context.AnDatItems.ToListAsync();
        }

        // GET: api/AnDat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnDatItem>> GetAnDatItem(long id)
        {
            var anDatItem = await _context.AnDatItems.FindAsync(id);

            if (anDatItem == null)
            {
                return NotFound();
            }

            return anDatItem;
        }

        // PUT: api/AnDat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnDatItem(long id, AnDatItem anDatItem)
        {
            if (id != anDatItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(anDatItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnDatItemExists(id))
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

        // POST: api/AnDat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnDatItem>> PostAnDatItem(AnDatItem anDatItem)
        {
            _context.AnDatItems.Add(anDatItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnDatItem", new { id = anDatItem.Id }, anDatItem);
        }

        // DELETE: api/AnDat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnDatItem(long id)
        {
            var anDatItem = await _context.AnDatItems.FindAsync(id);
            if (anDatItem == null)
            {
                return NotFound();
            }

            _context.AnDatItems.Remove(anDatItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnDatItemExists(long id)
        {
            return _context.AnDatItems.Any(e => e.Id == id);
        }
    }
}
