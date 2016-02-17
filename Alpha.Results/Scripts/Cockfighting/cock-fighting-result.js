/* File Created: December 16, 2015 */

"use strict";
var cockFightingResult = function (resultApi) {
    var me = this;
    var _ajaxRequest = null;
    var _intervalId = 0;
    var _resultApi = resultApi;
    me.extendSession = function () {
        _intervalId = setInterval(function () {
            var option = {
                cache: false,
                url: _resultApi + "?IsKeepAlive=true"
            };

            if (_ajaxRequest != null) {
                _ajaxRequest.abort();
            }
            _ajaxRequest = $.ajax(option);
        }, 60000);
    };
    me.Open = function () {
        var option = {
            type: "GET",
            cache: false,
            url: _resultApi,
            success: function (response) {
                clearInterval(_intervalId);
                if (response.IsSuccess) {
                    var linkResult = $('#result-link');
                    linkResult.attr('href', response.Url).show();

                    linkResult.click(function (e) {
                        e.preventDefault();
                        window.open(response.Url, 'Cockfighting-Result', 'width=900,height=700,directories=0,titlebar=0,toolbar=0,location=0,status=0,menubar=0');
                    });

                    me.extendSession();
                } else {
                    alert($('#FailedToConnectMessage').val());
                }
            },
            beforeSend: function () {
                //place your block UI
            },
            complete: function () {
                //place your block UI
            }
        };
        if (_ajaxRequest != null) {
            _ajaxRequest.abort();
        }
        _ajaxRequest = $.ajax(option);
    };
};
