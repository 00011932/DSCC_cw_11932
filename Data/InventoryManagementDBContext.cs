using API_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Backend.Data
{
    public class InventoryManagementDBContext : DbContext
    {
        // Constructor for the database context that takes options for configuration.
        public InventoryManagementDBContext(DbContextOptions<InventoryManagementDBContext> options) : base(options) 
        {
            // database ensure created methods used to check if the database created or not. if not it creates it automatically
            Database.EnsureCreated();
        }

        // DbSet representing the 'Items' table in the database.
        public DbSet<Item> Items { get; set; }

        // DbSet representing the 'Transactions' table in the database.
        public DbSet<Transaction> Transactions { get; set; }
    }

}





