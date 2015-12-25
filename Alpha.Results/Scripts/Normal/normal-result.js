/// <reference path="../jquery-1.11.3.intellisense.js" />

"use strict";

var normalResult =
{
    domElements:
        {
            txtResultDate: null,
            btnOtherDay: null,
            txtMinResultDate: null,
            dpkContainer: null,
            resultForm: null
        },
    init: function () {
        normalResult.cacheElements();
        normalResult.registerEvents();
    },
    cacheElements: function()
    {
        normalResult.domElements.txtResultDate = $('#ResultDate');
        normalResult.domElements.btnOtherDay = $('.btn-other-day');
        normalResult.domElements.txtMinResultDate = $('#MinResultDate');
        normalResult.domElements.dpkContainer = $('#dpkContainer');
    },
    registerEvents: function()
    {
        normalResult.domElements.dpkContainer.datetimepicker({
            minDate: normalResult.domElements.txtMinResultDate.val()
        });

        normalResult.domElements.btnOtherDay
            .off('click.normalResult')
            .on('click.normalResult', function () {
                var $this = $(this);

                normalResult.domElements.dpkContainer.data("DateTimePicker").date($this.attr('value'));
            });
    }

};

$(function () {
    normalResult.init();
})