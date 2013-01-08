using System;
using System.Linq;
using SignalRPlusEncodingTest.ApplicationServices;
using SignalRPlusEncodingTest.Models;

namespace SignalRPlusEncodingTest.Hubs
{
    public class AlertsHub : HubBase
    {
        /// <summary>
        ///Iin leui of IOC
        /// </summary>
        private static readonly IAlertsService _alertsService = new AlertsService();

        public override void Connected()
        {
            BroadcastAllActiveAlerts(Clients.Caller);
        }

        public override void Disconnected()
        {   }

        public override void Reconnected()
        {
            BroadcastAllActiveAlerts(Clients.Caller);
        }

        public void CreateAlert()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 10);
            var shouldFail = randomNumber % 2 == 0;

            var alert = new Alert
            {
                Id = Guid.NewGuid(),
                StartDateTimeUtc = shouldFail ? DateTime.Now : DateTime.UtcNow,
                Description = "Test Alert " + (_alertsService.AllActive().Count() + 1)
            };

            _alertsService.Create(alert);

            Clients.All.newAlert(alert);
        }

        public bool AcknowledgeAlert(Alert alert)
        {
            var isSuccessful = _alertsService.AcknowledgeAlert(alert.Id);

            if (isSuccessful)
                BroadcastAlertAcknowledged(Clients.Others, _alertsService.Single(alert.Id));

            return isSuccessful;
        }

        private void BroadcastAllActiveAlerts(dynamic connections)
        {
            var rackPowerManagementAlerts = _alertsService.AllActive();
            connections.init(rackPowerManagementAlerts);
        }

        private void BroadcastAlertAcknowledged(dynamic connections, Alert alert)
        {
            connections.alertAcknowledged(alert);
        }
    }
}