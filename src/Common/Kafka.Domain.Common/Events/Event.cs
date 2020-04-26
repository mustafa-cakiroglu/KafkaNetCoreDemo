using System;

namespace Kafka.Domain.Common.Events
{
    public abstract class Event
    {
        protected Event()
        {
            EventId = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public Guid EventId { get; }
        public DateTime Timestamp { get; }
    }
}
