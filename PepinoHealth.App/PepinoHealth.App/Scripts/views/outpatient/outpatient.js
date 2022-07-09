/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var validateOPUrl = null;

// Alert  messages


////////////////////////////////
// Login view functions start //
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
//////////////////////////////
// Login view functions end //
//////////////////////////////