using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models
{

    //One order has multuple items. 
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime CreatedDateTime { get; set; }
        public decimal? OrderPrice { get; set; } 
        public decimal? OrderTax { get; set; } 

    }
}
