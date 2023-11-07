using System.Text.Json.Serialization;

namespace API_Backend.Models
{
    // This is the 'Transaction' class, which represents a transaction in the database.
    public class Transaction
    {
        // This property represents the unique identifier for a transaction.
        public int ID { get; set; }

        // This property represents the ID of the associated item involved in the transaction.
        public int ItemId { get; set; }

        // This property stores the date and time when the transaction occurred.
        public DateTime TransactionDate { get; set; }

        // This property holds the count of items sold in the transaction.
        public int SoldItemsCount { get; set; }

        // This property represents the associated 'Item' object, which can be null.
        public Item? Item { get; set; }
    }
}
