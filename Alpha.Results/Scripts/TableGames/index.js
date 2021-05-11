$(function () {
    var linkTableGamesResult = $('#result-link');
    var url = linkTableGamesResult.attr('href');

    linkTableGamesResult.click(function (e) {
        e.preventDefault();
        window.open(url, 'TableGames_Result', 'width=900,height=700,scrollbars=1,directories=0,titlebar=0,toolbar=0,location=0,status=0,menubar=0');
    });
})