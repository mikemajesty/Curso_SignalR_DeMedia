$(function () {
    var colors = ["black", "red", "green", "blue", "yellow", "magenta", "white"];
    var canvas = $("#canvas");
    var colorElement = $("#color");
    for (var position = 0; position < colors.length; position++) {
        colorElement.append("<option value'" + position + 1 + "'>" + colors[position] + "</li>");
        console.log("<option value'" + position + 1 + "'>" + colors[position] + "</li>");
    }
  
    var buttonPressed = false;
    canvas.mousedown(function () {
        buttonPressed = true;

    }).mouseup(function () {
        buttonPressed = false;
    }).mousemove(function (e) {
        if (buttonPressed) {
            setPoint(e.offsetX, e.offsetY, colorElement.val());
        }
    });
    var ctx = canvas[0].getContext("2d");
    function setPoint(x, y, color) {
        ctx.fillStyle = color;
        ctx.beginPath();
        ctx.arc(x, y, 2, 0, Math.PI * 2);
        ctx.fill();
    }
    function clearPoints() {
        ctx.clearRect(0, 0, canvas.width(), canvas.height());
    }
    $('#clear').click(function () {
        clearPoints();
    });
    var hub = $.connection.board;
    hub.state.color = colorElement.val();
    var connected = false;
    colorElement.change(function () {
        hub.state.color = $(this).val();
    })
    canvas.mousemove(function (e) {
        if (buttonPressed & connected) {
            hub.server.broadCastPoint(Math.round(e.offsetX), Math.round(e.offsetY));
        }
    });
    $('#clear').click(function () {
        if (connected) {
            hub.server.broadcastClear();
        }
    });
    hub.client.clear = function () {
        clearPoints();
    }
    hub.client.drawPoint = function (x, y, color) {
        setPoint(x, y, color);
    }
    hub.client.update = function (points) {
        if (!points) return;
        for (var x = 0; x < 250; x++) {
            for (var y = 0; y < 250; y++) {
                if (points[x][y]) {
                    setPoint(x, y, points[x][y]);
                }
            }
        }
    }
    $.connection.hub.start().done(function () {
        connected = true;
    });
});