namespace StoreAPI.Models.Dtos
{
    public class GetOrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal? OrderItemPrice { get; set; }
    }
}
