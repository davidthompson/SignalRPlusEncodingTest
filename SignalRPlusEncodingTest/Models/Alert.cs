using System;

namespace SignalRPlusEncodingTest.Models
{
    public class Alert
    {
        public Guid Id { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime? EndDateTimeUtc { get; set; }
        public DateTime? AcknowledgedDateTimeUtc { get; set; }
        public string Description { get; set; }
    }
}