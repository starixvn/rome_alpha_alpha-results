(function () {
    'use strict';

    var rootUrl = $('#RootURL').val();
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

        fromdatepicker = $('#dpk-fromdate').datetimepicker(dpkSettings);
        todatepicker = $('#dpk-todate').datetimepicker(dpkSettings);

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

        $('#btn-excel').click(function () {
            var requestParams = {
                fromDate: fromdatepicker.data('date'),
                toDate: todatepicker.data('date'),
                sportId: $('#SportId').val(),
                leagueId: $('#LeagueId').val()
            };

            console.dir(requestParams);

            var downloadUrl = rootUrl + 'Outright/ExcelResults?' + $.param(requestParams);

            var iframe = $('#ifrm-exportExcel');
            if (iframe.length === 0) {
                iframe = $('<iframe id="ifrm-exportExcel" width="0" height="0" class="display-none"></iframe>');
                iframe.appendTo('body');
            }

            iframe.attr('src', downloadUrl);
        });
    }

    function initialize() {
        initializeDatepicker();
        registerEvents();
    }

    initialize();
})();
