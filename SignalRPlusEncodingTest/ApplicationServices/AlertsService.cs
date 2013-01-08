using System;
using System.Collections.Generic;
using System.Linq;
using SignalRPlusEncodingTest.Models;

namespace SignalRPlusEncodingTest.ApplicationServices
{
    public class AlertsService : IAlertsService
    {
        public static IList<Alert> Alerts = new List<Alert>
        {
            new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = DateTime.UtcNow,
                EndDateTimeUtc = null,
                AcknowledgedDateTimeUtc = null,
                Description = "Test Alert 1",
            },
            new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = DateTime.UtcNow,
                EndDateTimeUtc = null,
                AcknowledgedDateTimeUtc = null,
                Description = "Test Alert 2",
            },
            new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = DateTime.UtcNow,
                EndDateTimeUtc = null,
                AcknowledgedDateTimeUtc = null,
                Description = "Test Alert 3",
            },
            new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = DateTime.UtcNow,
                EndDateTimeUtc = null,
                AcknowledgedDateTimeUtc = null,
                Description = "Test Alert 4",
            },
            new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = DateTime.UtcNow,
                EndDateTimeUtc = null,
                AcknowledgedDateTimeUtc = null,
                Description = "Test Alert 5",
            }
        };

        public IEnumerable<Alert> AllActive()
        {
            return Alerts.Where(a => a.AcknowledgedDateTimeUtc == null);
        }

        public Alert Single(Guid id)
        {
            return Alerts.SingleOrDefault(a => a.Id == id);
        }

        public bool AcknowledgeAlert(Guid alertId)
        {
            Single(alertId).AcknowledgedDateTimeUtc = DateTime.UtcNow;
            return true;
        }

        public void Create(Alert alert)
        {
            Alerts.Add(alert);
        }
    }
}