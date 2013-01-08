SignalRPlusEncodingTest.Alerts = function () {

    var alertsHub = $.connection.alertsHub;

    var allAlerts;

    alertsHub.client.init = function (alerts) {

        allAlerts = alerts;

        $("#Alerts").empty();
        $.each(allAlerts, function () {
            if (this.StartDateTimeUtc.endsWith("Z"))
                $("#Alerts").prepend("<li data-id=\"" + this.Id + "\">" + this.Description + " - " + this.StartDateTimeUtc + " - <button class=\"ack\">Acknowledge (will work)</button></li>");
            else
                $("#Alerts").prepend("<li data-id=\"" + this.Id + "\">" + this.Description + " - " + this.StartDateTimeUtc + " - <button class=\"ack\">Acknowledge (will fail)</button></li>");
        });
    };

    alertsHub.client.newAlert = function (newAlert) {
        allAlerts.push(newAlert);
        
        if (newAlert.StartDateTimeUtc.endsWith("Z"))
            $("#Alerts").prepend("<li data-id=\"" + newAlert.Id + "\">" + newAlert.Description + " - " + newAlert.StartDateTimeUtc + " - <button class=\"ack\">Acknowledge (will work)</button></li>");
        else 
            $("#Alerts").prepend("<li data-id=\"" + newAlert.Id + "\">" + newAlert.Description + " - " + newAlert.StartDateTimeUtc + " - <button class=\"ack\">Acknowledge (will fail)</button></li>");
    };
    
    alertsHub.client.alertAcknowledged = function (acknowledgedAlert) {
        allAlerts.remove(acknowledgedAlert);
        $("#Alerts").find("[data-id='" + acknowledgedAlert.Id + "']").remove();
    };

    $("#Alerts").delegate(".ack", "click", function () {

        var alertId = $(this).parent().data("id");
        var alert = $.grep(allAlerts, function (e) { return e.Id == alertId; })[0];

        alertsHub.server.acknowledgeAlert(alert).done(function () {
            $("#Alerts").find("[data-id='" + alertId + "']").remove();
        });

    });

    $("#NewAlert").click(function() {
        alertsHub.server.createAlert();
    });

    return {
    };

}();