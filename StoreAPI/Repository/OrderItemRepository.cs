using StoreAPI.Data;
using StoreAPI.Models;
using StoreAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateOrderItem(OrderItem orderItem)
        {
            _db.Add(orderItem);
            return Save();
        }

        public ICollection<OrderItem> GetOrderItemsByOrderId(int orderId)
        {

            return _db.OrderItems.Where(x => x.OrderId == orderId).OrderBy(x => x.ItemId).ToList();
               
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
