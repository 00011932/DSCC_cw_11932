using API_Backend.Data;
using API_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // Constructor injecting database context for ItemController.
        private readonly InventoryManagementDBContext _dbContext;

        public ItemController(InventoryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/items   
        // GetItems method is used to get all Items from the Database and returns list of items as a response
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _dbContext.Items.ToListAsync();
            return Ok(items);
        }

        // GET: api/item/{id}
        // GetItem method is used to get a single Item from the Database according to recived id 
        // If item does not exist then method returns NotFound 404
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _dbContext.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/items

        // Post CreateItem method is used to create new Item in Db
        [HttpPost]
        public async Task<ActionResult<Item>> Createitem(Item item)
        {
            // creates item and saves changes
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.ID }, item);
        }

        // PUT: api/item/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Item item)
        {
            // first finds the item with given id then if it exists updates if not returns not found

            var existingitem = await _dbContext.Items.FindAsync(id);

            if (existingitem == null)
            {
                return NotFound();
            }
                 

            existingitem.Name = item.Name;
            existingitem.Description = item.Description;
            existingitem.Price = item.Price;
            existingitem.Quantity = item.Quantity;
            existingitem.CreatedAt = item.CreatedAt;
            existingitem.Category = item.Category; 

            await _dbContext.SaveChangesAsync();

            return Ok(existingitem);
        }

        // DELETE: api/item/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            // action for deleting item. First finds the item by its id. if it exists then delets it
            var existingItem = await _dbContext.Items.FindAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _dbContext.Items.Remove(existingItem);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
