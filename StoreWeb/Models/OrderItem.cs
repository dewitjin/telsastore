using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StoreWeb.Models
{
    public class OrderItem
    {
        [Required]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal? OrderItemPrice { get; set; }
    }
}
