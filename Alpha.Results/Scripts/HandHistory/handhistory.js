$(document).ready(function () {
    var handHistory = new HandHistory();
    handHistory.initPage();
});

var HandHistory = function () {
    var self = this;
    var handHistoryInfo = JSON.parse($("#HandHistory").val());

    self.initPage = function () {
        if (!handHistoryInfo.IsSuccess) {
            self.showAlertMessage("handhistory-result", handHistoryInfo.ResultMessage);
        } else {
            var iframe = '<iframe src="' + handHistoryInfo.Iframe + '" frameborder="0" class="handhistory-iframe"></iframe>';
            self.setIframe(iframe);
        }
    };

    self.showAlertMessage = function (containerid, msg) {
        $("#" + containerid).removeClass("hidden");
        document.getElementById(containerid).innerHTML = "<div class='alertboxerr'><span class='icon-error'><span>" + msg + "</div>";
    };

    self.setIframe = function (iframe) {
        $("#handhistory-result").html(iframe);
    };
};
