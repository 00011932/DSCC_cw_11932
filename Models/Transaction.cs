﻿using System.Text.Json.Serialization;

namespace API_Backend.Models
{
    public class Transaction
    {
        public int ID { get; set; }

        public int ItemId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int SoldItemsCount { get; set; }

        public Item? Item { get; set; } 
    }
} 