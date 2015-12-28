(function () {
    'use strict';

    var minResultDate = $('#MinResultDate').val(),
        maxResultDate = $('#MaxResultDate').val();
    var fromdatepicker, todatepicker;

    function initializeDatepicker() {
        var dpkSettings = {
            allowInputToggle: false,
            calendarWeeks: true,
            dayViewHeaderFormat: 'MMM YYYY',
            format: 'MM/DD/YYYY',
            showTodayButton: true,
            ignoreReadonly: true,
            minDate: minResultDate,
            maxDate: maxResultDate
        };

        fromdatepicker = $('#dpkFromDate').datetimepicker(dpkSettings);
        todatepicker = $('#dpkToDate').datetimepicker(dpkSettings);

        /*fromdatepicker.on('dp.change', function (e) {
            todatepicker.data('DateTimePicker').minDate(e.date);
        });

        todatepicker.on('dp.change', function (e) {
            fromdatepicker.data('DateTimePicker').maxDate(e.date);
        });*/
    }

    function registerEvents() {
        $('.btn-other-day').click(function () {
            var date = $(this).attr('value');
            fromdatepicker.data('DateTimePicker').date(date);
            todatepicker.data('DateTimePicker').date(date);
        });
    }

    function initialize() {
        initializeDatepicker();
        registerEvents();
    }

    initialize();
})();
