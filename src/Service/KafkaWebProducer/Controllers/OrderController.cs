using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kafka.Domain.Common.Interfaces;
using KafkaWebProducer.Domain.Interfaces;
using KafkaWebProducer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KafkaWebProducer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IEventManager _bus;
        private readonly IOrderService _orderService;

        public OrderController(IEventManager bus, IOrderService orderService)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _orderService = orderService;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] int id)
        {
            var order = new Order();
            order.Id = id;
            order.OrderDate = DateTime.Now;
            _orderService.CreateOrder(order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
