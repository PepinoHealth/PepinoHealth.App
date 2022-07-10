/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var deptUrl   = null;
var IPDRegUrl = null;

// TempData varaibles to maintain data
var validUser = null;


// Common  methods
function bindControlsOnLoadInOPOPReports() {
    registerEventsInOPRegistration();

    applyDatePicker(
        'txtStartDateTime',
        calendarFormatType.Date,
        function (e, date) {
        });
    hideModal('loader');
    applyDatePicker(
        'txtEndDateTime',
        calendarFormatType.Date,
        function (e, date) {
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
                //$('#ddlDepartment').empty();
                $.each(data, function (key, value) {

                    $('#ddlIPDDepartment').append($("<option></option>").val(data[key].DeptName).html(data[key].DeptName));
                });
            }
        });
    
}
function GetIPDRegistrationDetails() {
    var dept = $('#ddlIPDDepartment').val();
    var data = JSON.stringify({ Department: dept, StartDate: $('#txtStartDateTime').val(), EndDate: $('#txtEndDateTime').val() });

    callAPI(IPDRegUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data != null) {
                //if ($.fn.DataTable.isDataTable('#tbl-ipdregistration')) {
                //    $('#tbl-ipdregistration').DataTable().destroy();
                //}
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
                    hideModal('loader');
                }
                table = $('#tbl-ipdregistration').DataTable({
                    "deferRender": true,
                    "scrollX": true,
                    "autoWidth": false,
                    "select": true,

                    dom: 'Bfrtip',

                    lengthMenu: [
                        [10, 25, 50, -1],
                        ['10 rows', '25 rows', '50 rows', 'Show all']
                    ],
                    buttons: [
                        'pageLength',
                        'colvis',
                        {
                            extend: 'excelHtml5',
                            text: '<li class="fa fa-file-excel-o fa-lg fa_excel" aria-hidden="true">  </li> Excel  ',
                            titleAttr: 'Excel',
                            exportOptions: {
                                columns: ':visible'
                            }
                        },


                    ],
                    "initComplete": function (settings, json) {
                        $('body').find('.dataTables_scrollBody').addClass("scrollbar");
                    },
                }).columns.adjust().responsive.recalc();
            }
        });

}

function processOPIPReportsAction(object) {
    let actionTypeID = parseInt(object.data('action-id'));

    switch (actionTypeID) {
        case actionType.Save:
            GetIPDRegistrationDetails();

            break;
        case actionType.Refresh:

            alert('This action is from Refresh button.');

            break;
        case actionType.Print:

            alert('This action is from Print button.');

            break;
        case actionType.SaveAndPrint:

            alert('This action is from SaveAndPrint button.');

            break;
        case actionType.Modify:

            alert('This action is from Modify button.');

            break;
        case actionType.Delete:

            alert('This action is from Delete button.');

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
///////////////////////////////////////////////
// IPDPatientRegistration view functions end //
///////////////////////////////////////////////