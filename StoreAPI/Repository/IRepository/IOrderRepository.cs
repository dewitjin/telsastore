using StoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Repository.IRepository
{
    public interface IOrderRepository
    {
        Order GetOrder(DateTime CreatedTime, int CustomerId);
        public bool CreateOrder(Order order);
        public bool UpdateOrder(Order order);
        public bool Save();
    }
}
