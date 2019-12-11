using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Electronic.Data;
using Electronic.Data.Entities;

namespace Electronic.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemContext _context;

        public ItemsController(ItemContext context)
        {
            _context = context;
        }

        // GET: api/Items
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }*/

        // GET: api/Items/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }*/

        // GET: api/Items/iphone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemName(string name)
        {
            if (name == null)
            {
                return await _context.Items.ToListAsync();
            }
            else
            {
                return await _context.Items.Where(x => x.Title.Contains(name)).ToListAsync();
            }
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Items
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
