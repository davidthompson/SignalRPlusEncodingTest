
$(function () {

    $.connection.hub.logging = true;

    $.connection.hub.start()
        .fail(function () {
            //console.log("Could not connect");
        });

    $.connection.hub.reconnected(function () {
        //console.log('Reconnected');
    });

    $.connection.hub.stateChanged(function (change) {
        if (change.newState === $.signalR.connectionState.reconnecting) {
            //console.log('Re-connecting');
        } else if (change.newState === $.signalR.connectionState.connected) {
            //console.log('The server is online');
        }
    });

});