using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;


namespace StoreAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateCustomer(Customer customer)
        {
            _db.Add(customer);
            return Save();
        }

        public bool CustomerExists(string name)
        {
            bool value = _db.Customers.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public Customer GetCustomer(int customerId)
        {
            return _db.Customers.FirstOrDefault(x => x.Id == customerId);
        }

        public ICollection<Customer> GetCustomers()
        {
            return _db.Customers.OrderBy(x => x.Name).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
