

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.Dtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }

        public DateTime CreatedTime { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; } //List name has to be the same as mvc but the datatype can be different 
    }
}
