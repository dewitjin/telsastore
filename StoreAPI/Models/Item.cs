﻿using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

    }
}
