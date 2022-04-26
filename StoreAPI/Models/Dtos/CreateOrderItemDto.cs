

namespace StoreAPI.Models.Dtos
{
    //Properties of DTO and domain model has to be the same to use automapper
    //OrderId will be generated on server so the model will not have the property 
    public class CreateOrderItemDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
