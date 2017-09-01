var handHistory;
$(document).ready(function () {
    handHistory.initPage();
});

var HandHistory = function () {
    var self = this;
    self.initPage = function () {
        if (handHistoryInfo.ActionInfo && handHistoryInfo.ActionInfo.ResultCode) {
            self.showAlertMessage("handhistory-result", handHistoryInfo.ActionInfo.ResultMessage, 1);
        } else {
            var iframe = '<iframe src="' + handHistoryInfo.Iframe + '" frameborder="0" class="handhistory-iframe"></iframe>';
            self.setIframe(iframe);
        }
    };
    self.showAlertMessage = function (containerid, msg, type) {
        $("#" + containerid).removeClass("hidden");
        switch (type) {
            case 0:
                document.getElementById(containerid).innerHTML = "<div class='alertboxscc'><span class='icon-error'><span>" + msg + "</div>";
                break;
            case 1:
                document.getElementById(containerid).innerHTML = "<div class='alertboxerr'><span class='icon-error'><span>" + msg + "</div>";
                break;
            case 2:
                document.getElementById(containerid).innerHTML = "<div class='alertboxwrn'><span class='icon-error'><span>" + msg + "</div>";
                break;
            case 3:
                document.getElementById(containerid).innerHTML = msg;
                break;
            default:
                break
        }
    };
    self.setIframe = function (iframe) {
        $("#handhistory-result").html(iframe);
    };
};

var handHistory = new HandHistory();