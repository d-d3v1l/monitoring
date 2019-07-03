const socket = io('http://localhost:3000');

var errors = null;
var isError = false;
socket.on('new errors', function(err) {
    errors = err;
    $('#task-logs').addClass('task-logs-errors');
    $('.errors').show();
    var modalBody = $('.modal-body');
    modalBody.innerHTML = '';
    for (key in errors) {
        modalBody.append('<p>' + errors[key] + '</p>')
    }
    errors = null;
}) 

$('.errors').hover(function(e) {
    $('#error-modal').modal('show');
    $('.task-logs-errors').removeClass('task-logs-errors');
    $('.errors').hide();
})

