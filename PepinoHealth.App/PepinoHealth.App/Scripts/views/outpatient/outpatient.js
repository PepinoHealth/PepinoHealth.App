/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var validateOPUrl = null;
var deptUrl = null;
var addOPRegURL = null;
// Alert  messages


////////////////////////////////
// OPRegistration view functions start //
////////////////////////////////

function bindControlsOnLoadInOPRegistration() {
    registerEventsInOPRegistration();

    bindGetDepartmentDetails();
    bindgenerateBarcode();
    applyDateTimePicker(
        'txtDateTime',
        calendarFormatType.DateTime,
        function (e) {
        }
    );
    hideModal('loader');
}

function bindgenerateBarcode() {
    result = false;
    var data = JSON.stringify('');
    callAPI(validateOPUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {

            $('#barcodeImg').attr('src', "data:image/png;base64," + data);
        });

    return result;
}

function bindGetDepartmentDetails() {
    var data = JSON.stringify('');
    callAPI(deptUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data != null) {
                //$('#ddlDepartment').empty();
                $.each(data, function (key, value) {

                    $('#ddlDepartmentName').append($("<option></option>").val(data[key].DeptName).html(data[key].DeptName));
                });
            }
        });

}

function addOPRegistrationDetails() {
    var data = JSON.stringify({
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
    });
    callAPI(addOPRegURL, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data != null) {
                //$('#ddlDepartment').empty();
                $.each(data, function (key, value) {

                    $('#ddlDepartmentName').append($("<option></option>").val(data[key].DeptName).html(data[key].DeptName));
                });
            }
        });
}

function processOPRegistrationAction(object) {
    let actionTypeID = parseInt(object.data('action-id'));

    switch (actionTypeID) {
        case actionType.Save:

            alert('This action is from Save button.');

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
    $('#formRegistration .button-block button').on('click', function (e) {
        processOPRegistrationAction($(e.currentTarget));
    });
}
//////////////////////////////
// OPRegistration view functions end //
//////////////////////////////