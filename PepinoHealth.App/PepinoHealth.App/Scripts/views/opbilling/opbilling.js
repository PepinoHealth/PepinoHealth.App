/////////////////////////////////
// Local variable declarations //
/////////////////////////////////


// Action contol url variables to perform ajax calls


// TempData varaibles to maintain data


// Alert  messages


/////////////////////////////////////
// OP Billing view functions start //
/////////////////////////////////////

function bindControlsOnLoadInOPBilling() {
    registerEventsInOPBilling();

    hideModal('loader');
}

/////////////////////////////
// Billing Table functions //
/////////////////////////////

function processBillingTableActions(object) {
    let operationTypeID = parseInt(object.data('operation-id')),
        billingTableObject = $('.t-billing');

    switch (operationTypeID) {
        case operationType.Add:

            // #region Add new row.

            let newRowHTML =
                '<tr>' +
                '<td></td>' +
                '<td>' +
                '<input list="services" class="form-control" />' +
                '</td>' +
                '<td>' +
                '<input type="text" class="form-control" />' +
                '</td>' +
                '<td>' +
                '<input type="text" class="form-control form-currency" />' +
                '</td>' +
                '<td>' +
                '<input type="text" class="form-control form-currency" />' +
                '</td>' +
                '<td>' +
                '<input type="text" class="form-control form-currency" />' +
                '</td>' +
                '<td>' +
                '<div class="action">' +
                '<div class="remove" data-operation-id="' + operationType.Remove + '">' +
                '<i class="material-icons">remove</i>' +
                '</div>' +
                '</div>' +
                '</td>' +
                '</tr>';

            billingTableObject.find('tbody').append(newRowHTML);


            // #endregion

            break;
        case operationType.Remove:

            // #region Remove existing row.

            object.parents('tr').remove();

            // #endregion

            break;
    }

    resetRowNo();
    registerEventsInOPBilling();

    /* Supportive functions */
    function resetRowNo() {
        billingTableObject.find('tbody tr').each(function (key, row) {
            row = $(row);

            row.find('td:first-child').text((key + 1) + '.');
        });
    }
}

/////////////////////////
// Events Registration //
/////////////////////////
function registerEventsInOPBilling() {
    $('.t-billing tbody tr td .action .add, .t-billing tbody tr td .action .remove').off('click').on('click', function (e) {
        processBillingTableActions($(e.currentTarget));
    });
}

///////////////////////////////////
// OP Billing view functions end //
///////////////////////////////////