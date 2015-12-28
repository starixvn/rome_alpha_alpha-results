/// <reference path="../jquery-1.11.3.intellisense.js" />

"use strict";

var normalResult =
{
    resultDetailsUrl: 'Normal/ResultDetails?',
    domElements:
        {
            txtResultDate: null,
            btnOtherDay: null,
            txtMinResultDate: null,
            dpkContainer: null,
            resultForm: null,
            mainResult: null,
            rootUrl: null,
            resultDetails: null
        },
    init: function () {
        normalResult.cacheElements();
        normalResult.registerEvents();
    },
    cacheElements: function () {
        normalResult.domElements.txtResultDate = $('#ResultDate');
        normalResult.domElements.btnOtherDay = $('.btn-other-day');
        normalResult.domElements.txtMinResultDate = $('#MinResultDate');
        normalResult.domElements.dpkContainer = $('#dpkContainer');
        normalResult.domElements.mainResult = $('#main-result');
        normalResult.domElements.rootUrl = $('#RootURL');
        normalResult.domElements.resultDetails = $('#result-details');
    },
    registerEvents: function () {
        normalResult.domElements.dpkContainer.datetimepicker({
            minDate: normalResult.domElements.txtMinResultDate.val()
        });

        normalResult.domElements.btnOtherDay
            .off('click.normalResult')
            .on('click.normalResult', function () {
                var $this = $(this);

                normalResult.domElements.dpkContainer.data("DateTimePicker").date($this.attr('value'));
            });

        normalResult.domElements.mainResult
            .off('click.normalResult', '.detail-link')
            .on('click.normalResult', '.detail-link', function () {
                var $this = $(this),
                    requestParams = {
                        matchId: $this.data('match-id'),
                        leagueId: $this.data('league-id'),
                        sportId: $('#SportId').val()
                    };

                var resultDetailsUrl = normalResult.domElements.rootUrl.val()
                    + normalResult.resultDetailsUrl
                    + $.param(requestParams);

                normalResult.domElements.resultDetails.load(resultDetailsUrl, function () {
                    normalResult.domElements.resultDetails.modal({});
                });
            });
    }
};

$(function () {
    normalResult.init();
})