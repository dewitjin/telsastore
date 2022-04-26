using StoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository.IRepository
{
    public interface IOrderItemRepository
    {
        ICollection<OrderItem> GetOrderItemsByOrderId(int orderId);
        public bool CreateOrderItem(OrderItem orderItem);
        public bool Save();
    }
}
