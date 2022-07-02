/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls
var validateUserUrl = null;
var grantAccessUrl = null;
var quickLinksUrl = null;


// TempData varaibles to maintain data
var validUser = null;


// Alert  messages


////////////////////////////////
// Login view functions start //
////////////////////////////////

function bindControlsOnLoadInLogin() {
    validateNLogin();
    hideModal('loader');
}

function validateNLogin() {
    $('#formLogin').bootstrapValidator({
        live: liveType.Disabled,
        fields: {
            txtUsername: {
                validators: {
                    notEmpty: {
                        message: 'Required.'
                    }
                }
            },
            txtPassword: {
                validators: {
                    notEmpty: {
                        message: 'Required.'
                    },
                    callback: {
                        callback: function (value, validator, $field, data) {
                            let result = null;

                            if (value.length > 0) {
                                result = validateUser();

                                return {
                                    valid: result,
                                    message: 'The Username/Password combination is not valid. Try again.'
                                };
                            }

                            return true;
                        }
                    }
                }
            },
        },
    }).on('success.form.bv', function (e) {
        e.preventDefault();

        validateUserNNavigate();
    });
}

function validateUser() {
    var data = JSON.stringify({
        Username: $('#txtUsername').val().toLowerCase().trim(),
        Password: $('#txtPassword').val()
    }),
        result = false;

    callAPI(validateUserUrl, apiType.Post, asyncType.False, cacheType.False, data, dataNature.Json,
        function (data) {
            result = validUser = data.Valid;
        });

    return result;
}

function validateUserNNavigate() {
    let isValid = (validUser ? validUser : validateUser())

    if (isValid) {
        showModal('loader');
        readUserInfoNNavigate();
    }
}

function readUserInfoNNavigate() {
    let data = JSON.stringify({
        Username: $('#txtUsername').val().toLowerCase().trim()
    });

    let navigateUrl = quickLinksUrl;
 
    grantAccess(data, navigateUrl);
}

function grantAccess(data, navigateUrl) {
    callAPI(grantAccessUrl, apiType.Post, asyncType.True, cacheType.False, data, dataNature.Json,
        function (data) {
            if (data) {
                window.location.href = navigateUrl;
            }
        });
}

//////////////////////////////
// Login view functions end //
//////////////////////////////