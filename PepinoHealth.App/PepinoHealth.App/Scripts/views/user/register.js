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

///////////////////////////////
// Dashboard functions start //
///////////////////////////////

function bindControlsOnLoadInDashboard() {
    bindAppointmentChart();
    hideModal('loader');
}

function bindAppointmentChart() {
    let chartData = [
        { Month: "Jan 22", NoOfAppointments: 5, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Feb 22", NoOfAppointments: 4, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Mar 22", NoOfAppointments: 3, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Apr 22", NoOfAppointments: 10, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "May 22", NoOfAppointments: 2, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Jun 22", NoOfAppointments: 8, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Jun 22", NoOfAppointments: 6, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Aug 22", NoOfAppointments: 7, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Sep 22", NoOfAppointments: 4, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Oct 22", NoOfAppointments: 1, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Nov 22", NoOfAppointments: 3, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 },
        { Month: "Dec 22", NoOfAppointments: 9, NoOfCheckedIn: 0, NoOfNotCheckedIn: 0, NoOfCancelled: 0 }
    ];

    Chart.defaults.global.defaultFontFamily = 'HindSiliguri';

    var labels = Enumerable.From(chartData)
        .Select(function (x) { return x.Month })
        .ToArray();

    var data = Enumerable.From(chartData)
        .Select(function (x) { return x.NoOfAppointments })
        .ToArray();

    var cnsGraph = document.getElementById("cnsGraph").getContext("2d"),
        options = null,
        bgGradient = null,
        cnsChart = null,
        datasets = null,
        chartWidth = $('.p-body-content')[0].clientWidth - 20;

    $('#cnsGraph').css('width', chartWidth);

    options = {
        responsive: true,
        maintainAspectRatio: true,
        tooltips: {
            enabled: true,
            mode: 'single',
            custom: function (tooltip) {
                if (!tooltip) return;
                tooltip.displayColors = false;
            },
            callbacks: {
                title: function (tooltipItem, data) {
                    return moment(data['labels'][tooltipItem[0]['index']], "MMM YY").format("MMMM YYYY");
                },
                label: function (tooltipItems, data) {
                    var item = Enumerable.From(chartData)
                        .Where(function (x) { return x.Month == tooltipItems.xLabel })
                        .ToArray()[0];

                    var tooltipText = '';

                    tooltipText = ['Total Appointments: ' + item.NoOfAppointments];
                    tooltipText.push('Checked In Appointments: ' + item.NoOfCheckedIn);
                    tooltipText.push('Not Checked In Appointments: ' + item.NoOfNotCheckedIn);
                    tooltipText.push('Cancelled Appointments: ' + item.NoOfCancelled);

                    return tooltipText;
                },
            },
            backgroundColor: setRGBA(.65)
        },
        legend: {
            display: false
        },
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    fontSize: 14
                },
            }],
            xAxes: [{
                gridLines: {
                    drawOnChartArea: false
                },
                ticks: {
                    min: 0,
                    fontSize: 14
                },
            }]
        },
        elements: {
            point: {
                pointStyle: 'circle'
            }
        },
    };

    bgGradient = cnsGraph.createLinearGradient(0, 0, 0, 400);
    bgGradient.addColorStop(0, setRGBA(.5));
    bgGradient.addColorStop(1, setRGBA(0));

    datasets = [{
        lineThickness: 1,
        data: data,
        label: "",
        fill: true,
        lineTension: 0.4,
        borderWidth: 1,
        backgroundColor: bgGradient,
        borderColor: setRGBA(1),
        borderCapStyle: 'butt',
        borderDash: [],
        borderDashOffset: 0.0,
        borderJoinStyle: 'round',
        pointBorderColor: setRGBA(1),
        pointBackgroundColor: "#fff",
        pointBorderWidth: 1,
        pointHoverRadius: 7,
        pointHoverBackgroundColor: setRGBA(1),
        pointHoverBorderColor: setRGBA(1),
        pointHoverBorderWidth: 1,
        pointRadius: 5,
        pointHitRadius: 5,
        spanGaps: false,
        showLine: true,
    }];

    cnsChart = new Chart(cnsGraph, {
        type: 'line',
        data: {
            labels: labels,
            datasets: datasets
        },
        options: options
    });

    $('#cnsGraph').css('width', chartWidth);
}

/////////////////////////////
// Dashboard functions end //
/////////////////////////////