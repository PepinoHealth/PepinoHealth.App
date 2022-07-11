jQuery.fn.dataTableExt.oApi.fnFilterClear = function (a) {
    var b, c, e;
    if (a.oPreviousSearch.sSearch = "", "undefined" != typeof a.aanFeatures.f) {

        var d = a.aanFeatures.f;
        for (b = 0, c = d.length; b < c; b++) {
            e = $("input", d[b]);
            if (!e.hasClass('no-clear'))
                $("input", d[b]).val("");
        }

    }
    for (b = 0, c = a.aoPreSearchCols.length; b < c; b++) a.aoPreSearchCols[b].sSearch = "";
    a.oApi._fnReDraw(a)
};