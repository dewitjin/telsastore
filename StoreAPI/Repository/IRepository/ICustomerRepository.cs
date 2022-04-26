using StoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository.IRepository
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        bool CustomerExists(string name);
        bool CreateCustomer(Customer customer);//Need to seed the db
        bool Save();
    }
}
