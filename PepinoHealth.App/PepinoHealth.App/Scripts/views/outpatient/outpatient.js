/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var validateOPUrl = null;
var deptUrl = null;

// Alert  messages


////////////////////////////////
// OPRegistration view functions start //
////////////////////////////////

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
//////////////////////////////
// OPRegistration view functions end //
//////////////////////////////