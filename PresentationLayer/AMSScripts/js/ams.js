$(document).ready(function () {
    var table = $('#example').DataTable({
        //scrollY: false,
        //scrollX: true,
        //scrollCollapse: true,
        "searching": false,
        "info": false,
        paging: false
    });
    //$(document).on('click', 'td span.present', function () {
    //    $(this).toggleClass('atten_present');
    //    var s = $(this);
    //    var originaltext = s.text();
    //    $(this).text('P');
    //    s.text(originaltext);
    //    s.html(s.text() == 'P' ? 'A' : 'P');
    //});
//$(document).find('.holiday').text('-');

    $('#datepicker').Zebra_DatePicker();
    //$('#dailyDate').Zebra_DatePicker();

//$('#datepicker-range-start').Zebra_DatePicker({
//        show_week_number: 'Wk',
//        direction: -1
//    });

//    $('#datepicker-range-end').Zebra_DatePicker({
//        show_week_number: 'Wk',
//        direction: -1,
//        pair: $('#datepicker-range-start')
//    });
//    $('.datepickermonthly input').Zebra_DatePicker({
//        format: 'm Y'
//    });
    //$('.datepicker_selection, .daily_table, .weekly_table, .monthly_table').hide();
    //$(function () {
    //    $('#view_as').change(function () {
    //        $('.datepicker_selection').hide();
    //        $('.' + $(this).val()).show();
    //    });
    //});

     //$('.datePicker_nput').change(function() {
     //	// var dateVal = $(this).val();
     //	console.log('date change');
     //});

    //$('input.datePicker_input').on('blur', function () {
    //    var current = $(this).val();
    //    $('.selected_date').text(current);
    //});

    //$('input.datePicker_inputTo').on('blur', function () {
    //    var current = $(this).val();
    //    $('.selected_date').text("");
    //    $('.selected_dateTo').text("To: " + current);
    //});

    //$('#select_class').on('change', function () {
    //    var currentOption = $(this).val();
    //    $('.selected_class').text(currentOption);
    //});

    //$('.showTable').on('click', function () {
    //    var newVal = $('#view_as').val();
    //    console.log(newVal);
    //    if (newVal == 'daily') {
    //        $('.daily_table').show();
    //        $('.weekly_table').hide();
    //        $('.monthly_table').hide();
    //    }
    //    else if (newVal == 'weekly') {
    //        $('.weekly_table').show();
    //        $('.daily_table').hide();
    //        $('.monthly_table').hide();
    //    } else if (newVal == 'monthly') {
    //        $('.monthly_table').show();
    //        $('.weekly_table').hide();
    //        $('.daily_table').hide();
    //    }
    //});
    //$(function () {
    //    $('.monthly_table tr').each(function () {
    //        var tr = $(this),
    //            h = 0;
    //        tr.children().each(function () {
    //            var td = $(this),
    //                tdh = td.height();
    //            if (tdh > h) h = tdh;
    //        });
    //        tr.css({ height: h + 'px' });
    //    });
    //});


    //var today = new Date();
    //var dd = today.getDate();
    //var mm = today.getMonth() + 1; //January is 0!
    //var yyyy = today.getFullYear();

    //if (dd < 10) {
    //    dd = '0' + dd;
    //}

    //if (mm < 10) {
    //    mm = '0' + mm;
    //}
    //today = yyyy + '-' + mm + '-' + dd;

    //document.getElementById('datepicker').value = today;

    //document.getElementById('dailyDate').value = today;


});
