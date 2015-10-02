$(function () {
    var connection = $.connection("/conect");
    connection.start(function () {
        alert('Conect successful');
        startTrack();
    });
    function startTrack() {
        $('body').mousemove(function (e) {
            var data = { x: e.pageX, y: e.pageY, id: connection.id };
            connection.send(data);
        });
    }
    connection.received(function (data) {
        data = JSON.parse(data);
        var domElement = "id: " + data.id;
        var element = createElementIfNotExists(domElement);
        $(element).css({ left: data.x, top: data.y }).text(data.id);
    });

    function createElementIfNotExists(id) {
        var element = $('#' + id);
        if (element.length == 0) {
            element = $("<span class='client' id='" + id + "'></span>");
            element.css({
                backgroundcolor:RandomColor(),
                color:000000

            });
            $('body').append(element).show();
        }
        return element;
    }

    function RandomColor() {
        return "rgb(" + Math.round(Math.random() * 255 + 50) + "," + Math.round(Math.random() * 255 + 50) + "," + Math.round(Math.random() * 255 + 50) +")";
    }
});

