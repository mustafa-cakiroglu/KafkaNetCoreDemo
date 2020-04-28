using System;
using System.Threading.Tasks;
using KafkaWebProducer.Domain.Interfaces;
using KafkaWebProducer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KafkaWebProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task Post()
        {
            var order = new Order();
            order.Id = 5;
            order.OrderDate = DateTime.Now;
            await _orderService.CreateOrder(order).ConfigureAwait(false);
        }
    }
}
