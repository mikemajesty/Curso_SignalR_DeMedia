$(function () {
    var hub = $.connection.progressBarHub;
    hub.client.update = function (value) {
        console.log('método update');
        $('#progressBar').css("width", value, +"%").text(value + "%");
    };
    $('#start').click(function () {
        console.log('click button');
        $(this).attr('disabled', true)
        $('#result').hide('slow').load('HardProcess.aspx?connID=' + $.connection.hub.id, function () {
            $(this).slideDown('slow');
            $('#start').attr('disabled', false);
        });
    });
    $.connection.hub.start().done(function () {
        console.log('conectdado');
        $('#start').attr('disabled',false);
    });
});