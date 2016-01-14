$(function () {
    var api = new cockFightingResult($('#CockFightingResultUrl').val());
    api.Open();
    api.extendSession();
});