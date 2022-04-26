using AutoMapper;
using StoreAPI.Models;
using StoreAPI.Models.Dtos;


namespace StoreAPI.StoreMapper
{
    public class StoreMappings : Profile
    {
        public StoreMappings()
        {
            CreateMap<Customer, GetCustomerDto>().ReverseMap();
            CreateMap<OrderItem, GetOrderItemDto>().ReverseMap();
            CreateMap<Item, GetItemDto>().ReverseMap();         
        }

    }
}
