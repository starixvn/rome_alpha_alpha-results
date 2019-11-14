$(function () {
    const $cardClubIframe = $(".card-club-iframe");

    if ($cardClubIframe.length) {
        $(window).resize(function () {
            var height = $(window).height() - 10;
            $cardClubIframe.height(height < 0 ? 0 : height);
        });
    }
});