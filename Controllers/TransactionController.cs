using API_Backend.Data;
using API_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly InventoryManagementDBContext _dbContext;

        public TransactionController(InventoryManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // getting all transactions list 

         // GetAllTransactions method is used to get all Transactions from the Database and returns list of transactions as a response

        // returns empty list [] if there is no record in the db 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransactions()
        {
            var trns = await _dbContext.Transactions.Include(l => l.Item).ToListAsync();
            return Ok(trns);
        }


        // get transaction by id

        // GetTransactionById method is used to get a single Transaction from the Database according to recived id 
        // If transaction does not exist then method returns NotFound 404
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var trn = await _dbContext.Transactions.Include(l => l.Item).FirstOrDefaultAsync(l => l.ID == id);

            if (trn == null)
            {
                return NotFound();
            }

            return Ok(trn);
        }

        // create transaction

        // Post CreateTransaction method is used to create new transaction in Db
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction trn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the  item associated with the transaction
            var item = await _dbContext.Items.FindAsync(trn.ItemId);

            if ( item == null)
            {
                return NotFound();
            }

            // set transaction time to auto date time now
            trn.TransactionDate = DateTime.Now;


            // check if selected items count is less than or equal its original quantity in db
            if (item.Quantity - trn.SoldItemsCount < 0)
            {
                return BadRequest("Sold items count cant be more than actual item quantity");
                
            }
            item.Quantity -= trn.SoldItemsCount;
            trn.Item = item;

            // Add the transaction to the database
            _dbContext.Transactions.Add(trn);
            await _dbContext.SaveChangesAsync();


            return CreatedAtAction(nameof(GetTransactionById), new { id = trn.ID }, trn);
        }

        // update transaction

        [HttpPut("{id}")]
        public async Task<ActionResult<Transaction>> UpdateTransaction(int id, Transaction trn)
        {
            // first finds the trn with given id then if it exists updates if not returns not found
            if (id != trn.ID)
            {
                return BadRequest();
            }

            _dbContext.Entry(trn).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(trn);
        }

        // delete transaction

        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteTransaction(int id)
        {
            // action for deleting transaction. First finds the transaction by its id. if it exists then delets it. 
            var trn = await _dbContext.Transactions.FindAsync(id);
            if (trn == null)
            {
                return NotFound();
            }

            _dbContext.Transactions.Remove(trn);
            await _dbContext.SaveChangesAsync();

            return Ok(trn);

        }

        // Method to check whether Transaction exist or not, returns boolean
        private bool TransactionExist(int id)
        {
            return _dbContext.Transactions.Any(e => e.ID == id);
        }
    }
}
