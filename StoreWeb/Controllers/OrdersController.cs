using Microsoft.AspNetCore.Mvc;
using StoreWeb.Models;
using StoreWeb.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICustomerRepository _cRepo;
        private readonly IOrderRepository _oRepo;

        public OrdersController(ICustomerRepository cRepo, IOrderRepository oRepo)
        {
            _cRepo = cRepo;
            _oRepo = oRepo;
        }
        public IActionResult Index(Order order)
        {
            if (order.OrderPrice == null)
            {
                Order defaultOrder = new Order();
                defaultOrder.CustomerId = 1; //Customer Id key starts at 1
                defaultOrder.CustomerName = "James Bond";
                defaultOrder.CreatedDateTime = DateTime.Now;
                defaultOrder.OrderItems = new List<OrderItem>();

                defaultOrder.OrderItems.Add(new OrderItem { ItemId = 1002, Name = "Cyber Truck", Quantity = 0, OrderItemPrice = 0 });
                defaultOrder.OrderItems.Add(new OrderItem { ItemId = 1003, Name = "Model X", Quantity = 0, OrderItemPrice = 0 });

                defaultOrder.OrderTax = 0;
                defaultOrder.OrderPrice = 0;

                return View(defaultOrder);
            }
            else
            {
                return View(order);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var orderCreated = await _oRepo.CreateAsyncAndReturnObjToCreate(StaticDetails.OrderUrl, order);

            if (orderCreated == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                return View("OrderConfirmation", orderCreated); //This will take you to OrderConfirmation view, but the route will be https://localhost:44323/Orders/CreateOrder because it's under this controller
            }
            else
            {
                return View(order);
            }
        }
    }
}
