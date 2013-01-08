using System;
using System.Collections.Generic;
using SignalRPlusEncodingTest.Models;

namespace SignalRPlusEncodingTest.ApplicationServices
{
    public interface IAlertsService
    {
        IEnumerable<Alert> AllActive();
        Alert Single(Guid id);
        bool AcknowledgeAlert(Guid alertId);
        void Create(Alert alert);
    }
}