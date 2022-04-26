using StoreAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models
{

    //The API returns the following: customer name, total price for each item, the tax component, and the total price.
    // Properties here need to be the same in Order model in mvc, and will need total price for each item
    public class GetOrderDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDateTime { get; set; } 
        public List<OrderItem> OrderItems { get; set; }
        public decimal? OrderPrice { get; set; } 
        public decimal? OrderTax { get; set; }
    }
}
