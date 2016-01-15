$(function () {
    var linkKenoResult = $('#result-link');
    var url = linkKenoResult.attr('href');

    linkKenoResult.click(function (e) {
        e.preventDefault();
        window.open(url, '_blank', 'width=900, height=700');
    });

    linkKenoResult.trigger('click');
})


$(function () {
    function extendToken() {
        $.ajax({
            type: 'POST',
            url: $('#extend-token-url').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (rs) { },
            error: function (e) { },
            complete: function (e) { }
        });
    }

    setInterval(extendToken, 60 * 1000);
});