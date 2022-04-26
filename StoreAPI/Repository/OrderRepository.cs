using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateOrder(Order order)
        {
            _db.Add(order);
            return Save();
        }

        public Order GetOrder(DateTime createdDateTime, int customerId)
        {

           return _db.Orders.FirstOrDefault(x => x.CreatedDateTime == createdDateTime && x.CustomerId == customerId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;

        }

        public bool UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            return Save();
        }
    }
}
