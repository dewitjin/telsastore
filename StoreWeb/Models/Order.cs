using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Models
{
    public class Order
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; } 
        [Required]
        public List<OrderItem> OrderItems { get; set; }
        public string CustomerName { get; set; }
        public decimal? OrderPrice { get; set; }
        public decimal? OrderTax { get; set; }
    }
}
