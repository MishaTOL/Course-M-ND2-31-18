
    let hubUrl = 'https://localhost:44398/aligator';
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(hubUrl)
        .configureLogging(signalR.LogLevel.Information)
        .build();
    var lastData;
    hubConnection.on("Drow", function (x,y) {
        var data = {x: x, y: y };
    if (lastData == undefined)
        lastData = data;
    var $canvas = $("canvas");
    var context = $canvas[0].getContext("2d");
    context.beginPath();
    context.moveTo(lastData.x, lastData.y);
    context.lineTo(data.x, data.y);
    context.strokeStyle = color;
    context.stroke();
    lastData = data;
});

    document.getElementById("drower").addEventListener("mousemove", function (e) {
        if (e.which == 1) {
        hubConnection.invoke("Send", e.offsetX, e.offsetY);
    }
});

hubConnection.start();