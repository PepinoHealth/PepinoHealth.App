/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var deptUrl = null;
var IPDRegUrl = null;
var newVisitUrl = null;
var reVisitUrl = null;
var bothVisitUrl = null;
// TempData varaibles to maintain data
var validUser = null;


// Common  methods
function bindControlsOnLoadInOPOPReports() {
    registerEventsInOPRegistration();

    applyDateTimePicker(
        'txtStartDateTimeTime',
        calendarFormatType.Date,
        function (e) {
        });
    hideModal('loader');
    applyDateTimePicker(
        'txtEndDateTimeTime',
        calendarFormatType.Date,
        function (e) {
        });
    hideModal('loader');
}
function bindControlsOnLoadInOutPatientReports() {
    registerEventsInOutPatientRegistration();
    $('#tblnewvisit').hide();
    $('#tblrevisit').hide();
    $('#tblbothvisit').hide();
    $('#chkNewVisit').prop('checked', true);
    applyDateTimePicker(
        'txtStartDateTime',
        calendarFormatType.Date,
        function (e) {
        });
    hideModal('loader');
    applyDateTimePicker(
        'txtEndDateTime',
        calendarFormatType.Date,
        function (e) {
        });
    hideModal('loader');
}
/////////////////////////////////////////////////
// IPDPatientRegistration view functions start //
/////////////////////////////////////////////////
function bindGetIPDDepartmentDetails() {
    var data = JSON.stringify('');
    callAPI(deptUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data != null) {
                //$('#ddlIPDDepartment').empty();
                $.each(data, function (key, value) {

                    $('#ddlIPDDepartment').append($("<option></option>").val(data[key].DeptName).html(data[key].DeptName));
                });
            }
        });

}
function GetIPDRegistrationDetails() {
    var dept = $('#ddlIPDDepartment').val();
    var data = JSON.stringify({ Department: dept, StartDate: $('#txtStartDateTimeTime').val(), EndDate: $('#txtEndDateTimeTime').val() });

    callAPI(IPDRegUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data != null) {
                if ($.fn.DataTable.isDataTable('#tbl-ipdregistration')) {
                    $('#tbl-ipdregistration').DataTable().destroy();
                }
                $("#tbl-ipdregistration tbody").empty();
                if (data != null) {

                    $.each(data, function (key, value) {
                        var row = '<tr>' +
                            '<td>' + value.IPD_No + '</td>' +
                            '<td>' + formatDate(value.IPD_Date) + '</td>' +
                            '<td>' + value.IPD_Year + '</td>' +
                            '<td>' + value.IPD_Sub_Name + '</td>' +
                            '<td>' + value.IPD_Name + '</td>' +
                            '<td>' + value.IPD_Fathers_Name + '</td>' +
                            '<td>' + value.IPD_Husbands_Name + '</td>' +
                            '<td>' + value.IPD_Address + '</td>' +
                            '<td>' + value.IPD_Gender + '</td>' +
                            '<td>' + value.IPD_Age + '</td>' +
                            '<td>' + value.IPD_Dept_Name + '</td>' +
                            '<td>' + value.IPD_Ref_Doctor + '</td>' +
                            '</tr>';
                        $("#tbl-ipdregistration tbody").append(row);
                    });
                }
                table = $('#tbl-ipdregistration').DataTable({
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    responsive: true,
                    "order": [[0, "asc"]],
                    dom: 'Blfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                });
            }
        });
}
$(document).on('click', 'input[type="checkbox"]', function () {

    $('input[type="checkbox"]').not(this).prop('checked', false);
});
function GetRegistrationPatientDetails() {
    $('#tblnewvisit').hide();
    $('#tblrevisit').hide();
    $('#tblbothvisit').hide();

    if ($("#txtStartDateTime").val() == "" || $("#txtEndDateTime").val() == "") {
        showErrorAlert("no date selected");
        return;
    }

    if (Date.parse($('#txtStartDateTime').val()) > Date.parse($('#txtEndDateTime').val())) {
        showErrorAlert("startdate shouldn't be greater than enddate");
        return;
    }

    else {

        showModal('loader');

        var visit = $.map($('input[name="visit"]:checked'), function (c) { return c.value; })
        if (visit == "NEWVISIT") {

            $('#tblnewvisit').show();
            var dept = $('#ddlIPDDepartment').val();
            var data = JSON.stringify({ Visit: visit[0], Department: dept, StartDate: $('#txtStartDateTime').val(), EndDate: $('#txtEndDateTime').val() });

            callAPI(newVisitUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
                function (data) {

                    hideModal('loader');
                    if ($.fn.DataTable.isDataTable('#tbl-newvisit')) {
                        $('#tbl-newvisit').DataTable().destroy();
                    }
                    $("#tbl-newvisit tbody").empty();
                    if (data != null) {
                        $.each(data, function (key, value) {
                            var row = '<tr>' +
                                '<td>' + value.OP_NO + '</td>' +
                                '<td>' + value.OP_DATE + '</td>' +
                                '<td>' + value.OP_YEAR + '</td>' +
                                '<td>' + value.NAME_SUR + '</td>' +
                                '<td>' + value.OP_NAME + '</td>' +
                                '<td>' + value.OP_Father_Name + '</td>' +
                                '<td>' + value.OP_Husband + '</td>' +
                                '<td>' + value.OP_Address + '</td>' +
                                '<td>' + value.OP_Gender + '</td>' +
                                '<td>' + value.OP_AGE + '</td>' +
                                '<td>' + value.OP_DEPT_NAME + '</td>' +
                                '<td>' + value.OP_REF_DOCTOR + '</td>' +

                                '</tr>';
                            $("#tbl-newvisit tbody").append(row);
                        });


                        tablenew = $('#tbl-newvisit').DataTable({
                            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                            responsive: true,
                            "order": [[0, "asc"]],
                            dom: 'Blfrtip',
                            buttons: [
                                'copy', 'csv', 'excel', 'pdf', 'print'
                            ],
                        });

                        hideModal('loader');
                    }
                });

        }

        if (visit == "REVISIT") {

            $('#tblrevisit').show();
            var dept = $('#ddlIPDDepartment').val();
            var data = JSON.stringify({ Visit: visit[0], Department: dept, StartDate: $('#txtStartDateTime').val(), EndDate: $('#txtEndDateTime').val() });

            callAPI(reVisitUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
                function (data) {
                    hideModal('loader');
                    if ($.fn.DataTable.isDataTable('#tbl-revisit')) {
                        $('#tbl-revisit').DataTable().destroy();
                    }
                    $("#tbl-revisit tbody").empty();
                    if (data != null) {

                        $.each(data, function (key, value) {
                            var row = '<tr>' +
                                '<td>' + value.OP_NO + '</td>' +
                                '<td>' + value.OP_DATE + '</td>' +
                                '<td>' + value.OP_YEAR + '</td>' +
                                '<td>' + value.NAME_SUR + '</td>' +
                                '<td>' + value.OP_NAME + '</td>' +
                                '<td>' + value.OP_AGE + '</td>' +
                                '<td>' + value.OP_DEPT_NAME + '</td>' +
                                '<td>' + value.OP_REF_DOCTOR + '</td>' +
                                '</tr>';
                            $("#tbl-revisit tbody").append(row);
                        });

                        $('#tbl-revisit').DataTable({
                            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                            responsive: true,
                            "order": [[0, "asc"]],
                            dom: 'Blfrtip',
                            buttons: [
                                'copy', 'csv', 'excel', 'pdf', 'print'
                            ],
                        });
                        hideModal('loader');
                    }

                });


        }
        if (visit == "BOTHVISIT") {

            $('#tblbothvisit').show();
            var dept = $('#ddlIPDDepartment').val();
            var data = JSON.stringify({ Visit: visit[0], Department: dept, StartDate: $('#txtStartDateTime').val(), EndDate: $('#txtEndDateTime').val() });

            callAPI(bothVisitUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
                function (data) {
                    hideModal('loader');
                    if ($.fn.DataTable.isDataTable('#tbl-bothvisit')) {
                        $('#tbl-bothvisit').DataTable().destroy();
                    }
                    $("#tbl-bothvisit tbody").empty();
                    if (data != null) {
                        $.each(data, function (key, value) {
                            var row = '<tr>' +
                                '<td>' + value.FCh + '</td>' +
                                '<td>' + value.Opr_No + '</td>' +
                                '<td>' + value.Opr_Date + '</td>' +
                                '<td>' + value.Opr_Name + '</td>' +
                                '<td>' + value.Opr_Age + '</td>' +
                                '<td>' + value.Opr_Gender + '</td>' +
                                '<td>' + value.Opr_Dept_Name + '</td>' +
                                '<td>' + value.Opr_Category + '</td>' +
                                '<td>' + value.Opr_unit + '</td>' +
                                '<td>' + value.MCh + '</td>' +
                                '<td>' + value.O_FCh + '</td>' +
                                '<td>' + formatDate(value.From_Date) + '</td>' +
                                '<td>' + formatDate(value.To_Date) + '</td>' +
                                '</tr>';
                            var datapush = $("#tbl-bothvisit tbody").append(row);
                            //datapush.push([value.FCh, value.Opr_No, formatDate(value.Opr_Date), value.Opr_Name, value.Opr_Age, value.Opr_Gender, value.Opr_Dept_Name, value.Opr_Category, value.Opr_unit, value.MCh, value.O_FCh, value.From_Date, value.To_Date]

                        });

                        table = $('#tbl-bothvisit').DataTable({
                            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                            responsive: true,
                            "order": [[0, "asc"]],
                            dom: 'Blfrtip',
                            buttons: [
                                'copy', 'csv', 'excel', 'pdf', 'print'
                            ],
                        });
                        hideModal('loader');
                    }

                });


        }

    }
}
function processOPIPReportsAction(object) {
    let actionTypeID = parseInt(object.data('action-id'));

    switch (actionTypeID) {
        case actionType.Save:
            GetIPDRegistrationDetails();

            break;

    }
}
function processOutPatientReportsAction(object) {
    let actionTypeID = parseInt(object.data('action-id'));

    switch (actionTypeID) {
        case actionType.Save:
            GetRegistrationPatientDetails();
            break;
    }
}
/////////////////////////
// Events Registration //
/////////////////////////
function registerEventsInOPRegistration() {
    $('#formDebitDetails .button-block button').on('click', function (e) {
        processOPIPReportsAction($(e.currentTarget));
    });
}
function registerEventsInOutPatientRegistration() {
    $('#formOutPatient .button-block button').on('click', function (e) {
        processOutPatientReportsAction($(e.currentTarget));
    });
}
///////////////////////////////////////////////
// IPDPatientRegistration view functions end //
///////////////////////////////////////////////