const CanvasConnection = new signalR.HubConnectionBuilder()
    .withUrl('/canvas')
    .build();

var canvas = document.getElementById("myCanvas"),
    context = canvas.getContext("2d"),
    w = canvas.width,
    h = canvas.height;

var mouse = { x: 0, y: 0 };
var draw = false;

CanvasConnection.on("MouseDown", function (x, y) {
    draw = true;
    context.beginPath();
    context.moveTo(x, y);
});
CanvasConnection.on("MouseMove", function (x, y) {
    context.lineTo(x, y);
    context.stroke();
});
CanvasConnection.on("MouseUp", function (x, y) {
    context.lineTo(x, y);
    context.stroke();
    context.closePath();
    draw = false;
});

canvas.addEventListener("mousedown", function (e) {
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
    draw = true;
    CanvasConnection.invoke("MouseDown", mouse.x, mouse.y);
});
canvas.addEventListener("mousemove", function (e) {
    if (draw == true) {
        mouse.x = e.pageX - this.offsetLeft;
        mouse.y = e.pageY - this.offsetTop;
        CanvasConnection.invoke("MouseMove", mouse.x, mouse.y);
    }
});
canvas.addEventListener("mouseup", function (e) {
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
    draw = false;
    CanvasConnection.invoke("MouseUp", mouse.x, mouse.y);
});

CanvasConnection.start();