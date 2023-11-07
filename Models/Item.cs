using System.ComponentModel.DataAnnotations;

namespace API_Backend.Models
{
    // This is the 'Item' class, which represents an item in the database.
    public class Item
    {
        // This property represents the unique identifier for an item.
        public int ID { get; set; }

        // This property represents the name of the item with a maximum length of 100 characters.
        [StringLength(100)]
        public string Name { get; set; }

        // This property contains a description of the item.
        public string Description { get; set; }

        // This property holds the price of the item as a decimal number.
        public decimal Price { get; set; }

        // This property stores the quantity of the item available in stock.
        public int Quantity { get; set; }

        // This property represents the date and time when the item was created.
        public DateTime CreatedAt { get; set; }

        // This property specifies the category of the item using the 'CategoryTypes' enum.
        public CategoryTypes Category { get; set; }

        // This enum defines the possible categories for the 'Category' property.
        public enum CategoryTypes
        {
            Device = 0,   // Represents a device category (0)
            Furniture = 1, // Represents a furniture category (1)
            Other = 2     // Represents an 'Other' category (2)
        }
    }
}
