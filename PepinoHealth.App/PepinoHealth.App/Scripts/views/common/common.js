/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


/* Action contol url variables to perform ajax calls */



/* TempData varaibles to maintain data */



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
    return 'rgba(21, 148, 205,' + depth + ')';
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