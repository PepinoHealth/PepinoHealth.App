/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


/* Action contol url variables to perform ajax calls */



/* TempData varaibles to maintain data */
var primaryColor = null;



///////////////////
// Enum varaible //
///////////////////

var asyncType = {
    True: true,
    False: false
}

var apiType = {
    Get: "GET",
    Post: "POST",
    Delete: "DELETE"
}

var cacheType = {
    True: true,
    False: false
}

var dataNature = {
    Json: "json",
    Html: "html",
    Number: 1,
    Text: 2,
    DateTime: 3,
    Boolean: 4,
    Time: 5,
    Decimal: 6,
    Date: 7
}

var requestTimeout = {
    Five: 300000,
    Ten: 600000
}

var dateType = {
    MinDate: '01/01/0001',
    MaxDate: '12/31/9999',
}

var liveType = {
    Enabled: 'enabled',
    Disabled: 'disabled'
}

var calendarFormatType = {
    DateTime: 'DD/MM/YYYY hh:mm A',
    Date: 'DD/MM/YYYY',
    Year: 'YYYY',
    Time: 'hh:mm A'
}

////////////////////////////
// Common functions start //
////////////////////////////

function callAPI(url, type, async, cache, data, dataType, results) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        contentType: ("application/" + dataType + "; charset=utf-8"),
        dataType: dataType,
        async: async,
        cache: cache,
        timeout: requestTimeout.Five,
        success: function (data) {
            results(data);
        },
        error: function (data, textStatus, errorThrown) {
        }
    })
}

function callFormAPI(url, type, async, cache, data, results) {
    $.ajax({
        url: url,
        type: type,
        data: data,
        contentType: false,
        processData: false,
        async: async,
        cache: cache,
        timeout: requestTimeout.Five,
        success: function (data) {
            results(data);
        },
        error: function (data, textStatus, errorThrown) {
        }
    })
}

function callWebAPI(url, type, async, cache, data, dataType, header, results) {
    $.support.cors = true;

    $.ajax({
        url: url,
        type: type,
        data: data,
        contentType: ("application/" + dataType + "; charset=utf-8"),
        dataType: dataType,
        async: async,
        cache: cache,
        timeout: requestTimeout.Five,
        beforeSend: header,
        success: function (response) {
            results(response);
        },
        error: function (response) {
        }
    })
}

function showModal(e) {
    if ($('.initial-loader').hasClass('hide')) {
        $('.modal.show').modal('hide');
        $('.modal-backdrop.show').remove();

        $('#' + e).modal({
            backdrop: 'static',
            keyboard: false
        }).on('shown.bs.modal', function () {
            $('#btn-alert-ok,#btn-alert-no').focus();
        });
    }
}

function showInitialLoader() {
    $('.initial-loader').removeClass('hide');
}

function hideModal(e) {
    if (e != 'session-timeout')
        hideInitialLoader();

    $('#' + e).modal('hide');
}

function hideInitialLoader() {
    $('.initial-loader').addClass('hide');
}

function selectMenu(control) {
    $('#' + control).addClass('active');
}

function setRGBA(depth) {
    return 'rgba(' + primaryColor + ',' + depth + ')';
}

function setDays(days) {
    var date = new Date();
    date.setDate(date.getDate() + days);
    return date;
}

function applyDatePicker(control, calendarFormatTypeID, results) {
    let controlObject = $('#' + control),
        datePickerValues = getDatePickerValues(calendarFormatTypeID);

    controlObject.bootstrapMaterialDatePicker({
        format: calendarFormatTypeID,
        weekStart: 1,
        year: datePickerValues.Year,
        date: datePickerValues.Date,
        time: datePickerValues.Time,
        setDate: setDays(0),
        minDate: setDays(0),
        clearButton: true,
        nowButton: true,
        switchOnClick: true
    }).on('change', function (e, date) {
        results(e, date);
    });

    /* Support Events */
    controlObject.parents('.input-group').find('button').on('click', function () {
        controlObject.trigger('focus');
    });

    /* Support Functions */
    function getDatePickerValues(calendarFormatTypeID) {
        let year,
            date,
            time;

        switch (calendarFormatTypeID) {
            case calendarFormatType.Date:

                year = true;
                date = true;
                time = false;

                break;
            case calendarFormatType.Year:

                year = true;
                date = false;
                time = false;

                break;
            case calendarFormatType.Time:

                year = false;
                date = false;
                time = true;

                break;
            default:

                year = true;
                date = true;
                time = true;

                break;

        }

        return {
            Year: year,
            Date: date,
            Time: time
        }
    }
}

//////////////////////////
// Common functions end //
//////////////////////////


////////////////////////////
// Navbar functions start //
////////////////////////////



//////////////////////////
// Navbar functions end //
//////////////////////////


//////////////////////////////////
// Notification functions start //
//////////////////////////////////


////////////////////////////////
// Notification functions end //
////////////////////////////////

///////////////////////////
// OnLoad function start //
///////////////////////////

function callFuncOnLoad() {
    registerEventsInApp();
}

function registerEventsInApp() {
    $('.show_less,.show_more').on('click', function (e) {
        $(e.currentTarget).parents('.notify_data').toggleClass('more');
    });

    $('.toggle-burger').on('click', function () {
        $('ul.left-menu,div.right-menu').toggleClass('show');
    });

    $('.notification-bar i').on('click', function () {
        $('.notification_dd').toggleClass('active');
    });

    $(window).resize(function () {
        $('ul.left-menu,div.right-menu').removeClass('show');
    });
}

/////////////////////////
// OnLoad function end //
/////////////////////////