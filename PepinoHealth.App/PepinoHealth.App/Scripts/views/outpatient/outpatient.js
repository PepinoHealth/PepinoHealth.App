function addOPRegistrationDetails()
{
    $.ajax({
        type: 'POST',
        url: '@Url.Action("CRUDOPRegistrationDetails", "OutPatient")',
        data: JSON.stringify({
            OP_NO: $('#txtOPNo').val(),
            OP_DATE: $('#txtDate').val(),
            UHID: $('#txtUHID').val(),
            OP_PREPARED_BY: "Admin",
            OP_PRINT_COUNT: "",
            OP_YEAR: $('#txtYear').val(),
            OP_TIME: $('#txtTime').val(),
            OP_MODIFIED_BY: "Admin",
            NAME_SUR: $('#ddlNameTitle').val(),
            OP_NAME: $('#txtName').val(),
            OP_FATHER_NAME: $('#txtFatherName').val(),
            OP_HUSBAND: $('#txtHusbandName').val(),
            OP_AddRESS: $('#txtAddress').val(),
            OP_PLACE: "",
            OP_PHONE_NUM: $('#txtPhoneNo').val(),
            OP_RELIGION: "",
            OP_SUBCAST: "",
            OP_CATEGORY: $('#ddlCategory').val(),
            OP_GENDER: $('#ddlGender').val(),
            OP_DEPT_NAME: $('#ddlDepartment').val(),
            OP_UNIT_NO: "",
            OP_DOB: "",
            OP_AGE: $('#ddlAge').val(),
            OP_AGE1: $('#ddlYear').val(),
            OP_ROOM_NO: "",
            OP_OCCUPATION: "",
            OP_INCOME: "",
            OP_FEES: $('#txtCharge').val(),
            OP_REF_DOCTOR: $('#ddlRefDoctor').val(),
            OP_MARRRIED: $('#ddlMaritalStatus').val(),
            OP_COPERATE: "",
            DUMMYYN: "",
            OP_MONTH: "",
            LABYN: "",
            RAD_AGE: "",
            CARD_NUMBER: "",
            ALT_PHNO: $('#txtAlternatePhoneNo').val(),
            Token_No: $('#txtTokenNo').val(),
            ConsultantDR: $('#ddlConsultantDoctor').val(),
            Location: "",
            Barcode_No: "",
            Barcode_Image: "",
            MailID: "",
            AadhaarID: $('#txtAadhaarID').val(),
            OPID: "",
            COMPLAINTS: "",
            ONEXAMINATIONS: "",
            ADVICE: "",
            PatientType: $('#ddlPatientType').val(),
            MODE: 'SAVE'
        }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            if (data != null) {
                if (data[0].Result == true) {

                    showSuccessAlert('Successfully Inserted!');
                    clearAll();
                    bindCRUDDepotMasterDetails();
                }
                else {
                    showErrorAlert('This record is already exist ');
                }
            }
        }

    });
}
function bindCRUDOPDetails() {
    $('#OPDetailsModal').modal('show');
    showModal('loader');
    if ($("#txtStartDate").val() == "" || $("#txtEndDate").val() == "") {
        showErrorAlert("no date selected");
        return;
    }

    if (Date.parse($('#txtStartDate').val()) > Date.parse($('#txtEndDate').val())) {
        showErrorAlert("startdate shouldn't be greater than enddate");
        return;
    }
    var Data = JSON.stringify({ StartDate: $('#txtStartDate').val(), EndDate: $('#txtEndDate').val() });
    $.ajax({
        type: 'POST',
        url: '@Url.Action("CRUDOutPatientDetails", "OutPatient")',
        data: Data,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        dataFilter: function (data) {
            var json = jQuery.parseJSON(data);
            json.recordsTotal = json.total;
            json.recordsFiltered = json.total;
            json.data = json.list;

            return JSON.stringify(json); // return JSON string
        },
        success: function (data) {
            if ($.fn.DataTable.isDataTable('#tblOPDetails')) {
                $('#tblOPDetails').DataTable().destroy();
            }

            $("#tblOPDetails tbody").empty();

            if (data != null) {
                $.each(data, function (key, value) {
                    var row = '<tr>' +
                        '<td>' + '<a href="#" id="' + value.UHID + '" onclick=getOPDetailsByUHID(this)>' + value.UHID + '</a></td>' +
                        '<td>' + value.OP_NAME + '</td>' +
                        '<td>' + value.OP_DEPT_NAME + '</td>' +
                        '<td>' + value.OP_GENDER + '</td>' +
                        '<td>' + value.OP_AGE + '</td>' +
                        '</tr>';
                    $("#tblOPDetails tbody").append(row);
                });

                var table = $('#tblOPDetails').DataTable({
                    "scrollX": true,
                    "autoWidth": false,
                    "select": true,
                    dom: 'Bfrtip',
                    "pagingType": "full_numbers",
                    buttons: [
                        'pageLength',
                        {
                            extend: 'excelHtml5',
                            text: '<li class="fa fa-file-excel-o fa-lg fa_excel" aria-hidden="true" style="color:#f04124">  </li> Excel  ',
                            titleAttr: 'Excel',
                            exportOptions: {
                                columns: ':visible'
                            }
                        }
                    ],
                });
                hideModal('loader');
            }
        }

    });
}
function modalOutPatientPopup() {
    getDate();
    bindCRUDOPDetails();

}
function getOPDetailsByUHID(object) {
    var result = object.id
    $.ajax({
        type: 'POST',
        url: '@Url.Action("GetOPDetailsByUHID", "OutPatient")',
        data: JSON.stringify({ UHID: result }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {

            if (data != "") {
                $('#OPDetailsModal').modal('hide');
                $.each(data, function (key, value) {
                    $('#txtOPNo').val(value.OP_NO);
                    $('#txtUHID').val(value.UHID);
                    $('#txtYear').val(value.OP_YEAR);
                    $('#ddlNameTitle').val(value.NAME_SUR);
                    $('#txtName').val(value.OP_NAME);
                    $('#txtFatherName').val(value.OP_FATHER_NAME);
                    $('#txtHusbandName').val(value.OP_HUSBAND);
                    $('#txtAddress').val(value.OP_AddRESS);
                    $('#txtPhoneNo').val(value.OP_PHONE_NUM);
                    $('#ddlCategory').val(value.OP_CATEGORY);
                    $('#ddlGender').val(value.OP_GENDER);
                    $('#ddlDepartment').val(value.OP_DEPT_NAME);
                    $('#ddlAge').val(value.OP_AGE);
                    $('#txtCharge').val(value.OP_FEES);
                    $('#ddlRefDoctor').val(value.OP_REF_DOCTOR);
                    $('#ddlMaritalStatus').val(value.OP_MARRRIED);
                    $('#txtAlternatePhoneNo').val(value.ALT_PHNO);
                    $('#txtTokenNo').val(value.Token_No);
                    $('#ddlConsultantDoctor').val(value.ConsultantDR);
                    $('#txtAadhaarID').val(value.AadhaarID);
                    $('#ddlPatientType').val(value.PatientType);
                    $('#barcodeImg').attr('src', "data:image/png;base64," + value.BarcodeImage);
                });
            }
            else {
                showErrorAlert("no date found..!");
                return;
            }

        },

    });
}
function bindGetDepartmentDetails() {
    $.ajax({
        type: 'POST',
        url: '@Url.Action("CRUDDepotMasterDetails", "Admin")',
        data: JSON.stringify({ DeptCode: '', DeptName: '', DeptNoBed: 0, Flag: 'read' }),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {

            if (data != false) {
                //$('#ddlDepartment').empty();
                $.each(data, function (key, value) {

                    $('#ddlDepartment').append($("<option></option>").val(data[key].DeptName).html(data[key].DeptName));
                });
            }

        },

    });
}
function getDate() {
    var today = new Date();
    var todaydate = today.getFullYear() + '-' + ('0' + (today.getMonth() + 1)).slice(-2) + '-' + ('0' + today.getDate()).slice(-2);
    $('#txtStartDate').val(todaydate);
    $('#txtEndDate').val(todaydate);
    $('#txtDate').val(todaydate);
}
function bindgenerateBarcode() {
    debugger
    $.ajax({
        type: 'POST',
        url: '@Url.Action("generateBarcode", "OutPatient")',
        data: '{}',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (data) {
            $('#barcodeImg').attr('src', "data:image/png;base64," + data);
        },

    });
}