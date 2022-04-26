using StoreWeb.Models;
using System.Net.Http;

namespace StoreWeb.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public CustomerRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
