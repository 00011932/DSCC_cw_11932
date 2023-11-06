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
        public InventoryManagementDBContext(DbContextOptions<InventoryManagementDBContext> options) : base(options) 
        {
            // database ensure created methods used to check if the database created or not. if not it creates it automatically
            Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }

}





