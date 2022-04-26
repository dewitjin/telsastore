using Newtonsoft.Json;
using StoreWeb.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StoreWeb.Repository
{
    //Note: sending order item with Order as a List<OrderItem>
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public OrderRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
