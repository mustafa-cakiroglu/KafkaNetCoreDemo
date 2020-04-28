﻿using System.Collections.Generic;
using DotNetCore.CAP;
using Kafka.Domain.Common.Events;
using Microsoft.AspNetCore.Mvc;

namespace KafkaWebConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [NonAction]
        [CapSubscribe(nameof(OrderCreatedEvent))]
        public void HandleNotificationCreatedAlert(OrderCreatedEvent e)
        {

            var eventId = e.EventId;

        }
    }
}
