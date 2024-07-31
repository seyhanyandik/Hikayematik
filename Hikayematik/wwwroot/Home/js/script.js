$(document).ready(function () {
    $('.clickable-card').on('click', function () {
        var url = $(this).data('url');
        window.location.href = url;
    });
});