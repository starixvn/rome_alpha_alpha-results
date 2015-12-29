/// <reference path="../jquery-1.11.3.intellisense.js" />

"use strict";

var normalResult =
{
    resultDetailsUrl: 'Normal/ResultDetails?',
    excelResultsUrl: 'Normal/ExcelResults?',
    domElements:
        {
            txtResultDate: null,
            btnOtherDay: null,
            txtMinResultDate: null,
            dpkContainer: null,
            resultForm: null,
            mainResult: null,
            rootUrl: null,
            resultDetails: null,
            excelBtn: null,
            ddlSports: null,
            ddlLeagues: null,
            filterForm: null,
            frmDetailsResult: null
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
        normalResult.domElements.excelBtn = $('#excel-btn');
        normalResult.domElements.ddlSports = $('#SportId');
        normalResult.domElements.ddlLeagues = $('#LeagueId');
        normalResult.domElements.filterForm = $('#result-filter');
        normalResult.domElements.frmDetailsResult = $('#result-detail-frm');
    },
    registerEvents: function () {
        normalResult.domElements.dpkContainer.datetimepicker({
            minDate: normalResult.domElements.txtMinResultDate.val(),
            allowInputToggle: false,
            calendarWeeks: true,
            dayViewHeaderFormat: 'MMM YYYY',
            format: 'MM/DD/YYYY',
            showTodayButton: true,
            ignoreReadonly: true,
        });

        normalResult.domElements.btnOtherDay
            .off('click.normalResult')
            .on('click.normalResult', function () {
                var $this = $(this);

                normalResult.domElements.dpkContainer.data("DateTimePicker").date($this.attr('value'));
            });

        normalResult.domElements.ddlSports
            .off('change.normalResult')
            .on('change.normalResult', function () {
                normalResult.domElements.ddlLeagues.val('0');
                normalResult.domElements.filterForm.submit();
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

                normalResult.domElements.frmDetailsResult.attr('src', resultDetailsUrl);
                normalResult.domElements.resultDetails.modal({});
            });

        normalResult.domElements.excelBtn
            .off('click.normalResult')
            .on('click.normalResult', function () {
                var requestParams = {
                    resultDate: normalResult.domElements.txtResultDate.val(),
                    leagueId: $('#LeagueId').val(),
                    sportId: $('#SportId').val()
                },
                downloadUrl = normalResult.domElements.rootUrl.val()
                    + normalResult.excelResultsUrl
                    + $.param(requestParams);

                var iframe = $('body #iframeExportExcelFile');
                if (iframe.length === 0) {
                    iframe = $('<iframe id="iframeExportExcelFile" width="0" height="0" class="display-none"></iframe>');
                    iframe.appendTo('body');
                }

                iframe.attr('src', downloadUrl);
            });
    }
};

$(function () {
    normalResult.init();
})