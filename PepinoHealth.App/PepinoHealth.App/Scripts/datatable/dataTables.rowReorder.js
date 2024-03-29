﻿/*!
 RowReorder 1.2.0
 2015-2016 SpryMedia Ltd - datatables.net/license
*/
(function (e) {
    "function" === typeof define && define.amd ? define(["jquery", "datatables.net"], function (f) {
        return e(f, window, document)
    }) : "object" === typeof exports ? module.exports = function (f, g) {
        f || (f = window);
        if (!g || !g.fn.dataTable) g = require("datatables.net")(f, g).$;
        return e(g, f, f.document)
    } : e(jQuery, window, document)
})(function (e, f, g, n) {
    var l = e.fn.dataTable,
        j = function (c, b) {
            if (!l.versionCheck || !l.versionCheck("1.10.8")) throw "DataTables RowReorder requires DataTables 1.10.8 or newer";
            this.c = e.extend(!0, {}, l.defaults.rowReorder,
                j.defaults, b);
            this.s = {
                bodyTop: null,
                dt: new l.Api(c),
                getDataFn: l.ext.oApi._fnGetObjectDataFn(this.c.dataSrc),
                middles: null,
                scroll: {},
                scrollInterval: null,
                setDataFn: l.ext.oApi._fnSetObjectDataFn(this.c.dataSrc),
                start: {
                    top: 0,
                    left: 0,
                    offsetTop: 0,
                    offsetLeft: 0,
                    nodes: []
                },
                windowHeight: 0
            };
            this.dom = {
                clone: null,
                dtScroll: e("div.dataTables_scrollBody", this.s.dt.table().container())
            };
            var a = this.s.dt.settings()[0],
                d = a.rowreorder;
            if (d) return d;
            a.rowreorder = this;
            this._constructor()
        };
    e.extend(j.prototype, {
        _constructor: function () {
            var c =
                this,
                b = this.s.dt,
                a = e(b.table().node());
            "static" === a.css("position") && a.css("position", "relative");
            e(b.table().container()).on("mousedown.rowReorder touchstart.rowReorder", this.c.selector, function (a) {
                if (c.c.enabled) {
                    var h = e(this).closest("tr");
                    if (b.row(h).any()) return c._mouseDown(a, h), !1
                }
            });
            b.on("destroy.rowReorder", function () {
                e(b.table().container()).off(".rowReorder");
                b.off(".rowReorder")
            })
        },
        _cachePositions: function () {
            var c = this.s.dt,
                b = e(c.table().node()).find("thead").outerHeight(),
                a = e.unique(c.rows({
                    page: "current"
                }).nodes().toArray()),
                d = e.map(a, function (a) {
                    return e(a).position().top - b
                }),
                a = e.map(d, function (a, b) {
                    return d.length < b - 1 ? (a + d[b + 1]) / 2 : (a + a + e(c.row(":last-child").node()).outerHeight()) / 2
                });
            this.s.middles = a;
            this.s.bodyTop = e(c.table().body()).offset().top;
            this.s.windowHeight = e(f).height()
        },
        _clone: function (c) {
            var b = e(this.s.dt.table().node().cloneNode(!1)).addClass("dt-rowReorder-float").append("<tbody/>").append(c.clone(!1)),
                a = c.outerWidth(),
                d = c.outerHeight(),
                h = c.children().map(function () {
                    return e(this).width()
                });
            b.width(a).height(d).find("tr").children().each(function (a) {
                this.style.width =
                    h[a] + "px"
            });
            b.appendTo("body");
            this.dom.clone = b
        },
        _clonePosition: function (c) {
            var b = this.s.start,
                a = this._eventToPage(c, "Y") - b.top,
                c = this._eventToPage(c, "X") - b.left,
                d = this.c.snapX;
            this.dom.clone.css({
                top: a + b.offsetTop,
                left: !0 === d ? b.offsetLeft : "number" === typeof d ? b.offsetLeft + d : c + b.offsetLeft
            })
        },
        _emitEvent: function (c, b) {
            this.s.dt.iterator("table", function (a) {
                e(a.nTable).triggerHandler(c + ".dt", b)
            })
        },
        _eventToPage: function (c, b) {
            return -1 !== c.type.indexOf("touch") ? c.originalEvent.touches[0]["page" + b] : c["page" +
                b]
        },
        _mouseDown: function (c, b) {
            var a = this,
                d = this.s.dt,
                h = this.s.start,
                k = b.offset();
            h.top = this._eventToPage(c, "Y");
            h.left = this._eventToPage(c, "X");
            h.offsetTop = k.top;
            h.offsetLeft = k.left;
            h.nodes = e.unique(d.rows({
                page: "current"
            }).nodes().toArray());
            this._cachePositions();
            this._clone(b);
            this._clonePosition(c);
            this.dom.target = b;
            b.addClass("dt-rowReorder-moving");
            e(g).on("mouseup.rowReorder touchend.rowReorder", function (b) {
                a._mouseUp(b)
            }).on("mousemove.rowReorder touchmove.rowReorder", function (b) {
                a._mouseMove(b)
            });
            e(f).width() === e(g).width() && e(g.body).addClass("dt-rowReorder-noOverflow");
            d = this.dom.dtScroll;
            this.s.scroll = {
                windowHeight: e(f).height(),
                windowWidth: e(f).width(),
                dtTop: d.length ? d.offset().top : null,
                dtLeft: d.length ? d.offset().left : null,
                dtHeight: d.length ? d.outerHeight() : null,
                dtWidth: d.length ? d.outerWidth() : null
            }
        },
        _mouseMove: function (c) {
            this._clonePosition(c);
            for (var b = this._eventToPage(c, "Y") - this.s.bodyTop, a = this.s.middles, d = null, h = this.s.dt, k = h.table().body(), i = 0, g = a.length; i < g; i++)
                if (b < a[i]) {
                    d = i;
                    break
                }
            null === d && (d = a.length);
            if (null === this.s.lastInsert || this.s.lastInsert !== d) 0 === d ? this.dom.target.prependTo(k) : (b = e.unique(h.rows({
                page: "current"
            }).nodes().toArray()), d > this.s.lastInsert ? this.dom.target.insertAfter(b[d - 1]) : this.dom.target.insertBefore(b[d])), this._cachePositions(), this.s.lastInsert = d;
            this._shiftScroll(c)
        },
        _mouseUp: function () {
            var c = this,
                b = this.s.dt,
                a, d, h = this.c.dataSrc;
            this.dom.clone.remove();
            this.dom.clone = null;
            this.dom.target.removeClass("dt-rowReorder-moving");
            e(g).off(".rowReorder");
            e(g.body).removeClass("dt-rowReorder-noOverflow");
            clearInterval(this.s.scrollInterval);
            this.s.scrollInterval = null;
            var k = this.s.start.nodes,
                i = e.unique(b.rows({
                    page: "current"
                }).nodes().toArray()),
                f = {},
                j = [],
                l = [],
                m = this.s.getDataFn,
                n = this.s.setDataFn;
            a = 0;
            for (d = k.length; a < d; a++)
                if (k[a] !== i[a]) {
                    var o = b.row(i[a]).id(),
                        q = b.row(i[a]).data(),
                        p = b.row(k[a]).data();
                    o && (f[o] = m(p));
                    j.push({
                        node: i[a],
                        oldData: m(q),
                        newData: m(p),
                        newPosition: a,
                        oldPosition: e.inArray(i[a], k)
                    });
                    l.push(i[a])
                }
            k = [j, {
                dataSrc: h,
                nodes: l,
                values: f,
                triggerRow: b.row(this.dom.target)
            }];
            this._emitEvent("row-reorder", k);
            this.c.editor && (this.c.enabled = !1, this.c.editor.edit(l, !1, e.extend({
                submit: "changed"
            }, this.c.formOptions)).multiSet(h, f).one("submitComplete", function () {
                c.c.enabled = !0
            }).submit());
            if (this.c.update) {
                a = 0;
                for (d = j.length; a < d; a++) f = b.row(j[a].node).data(), n(f, j[a].newData), b.columns().every(function () {
                    this.dataSrc() === h && b.cell(j[a].node, this.index()).invalidate("data")
                });
                this._emitEvent("row-reordered", k);
                b.draw(!1)
            }
        },
        _shiftScroll: function (c) {
            var b =
                this,
                a = this.s.scroll,
                d = !1,
                e = c.pageY - g.body.scrollTop,
                f, i;
            65 > e ? f = -5 : e > a.windowHeight - 65 && (f = 5);
            null !== a.dtTop && c.pageY < a.dtTop + 65 ? i = -5 : null !== a.dtTop && c.pageY > a.dtTop + a.dtHeight - 65 && (i = 5);
            f || i ? (a.windowVert = f, a.dtVert = i, d = !0) : this.s.scrollInterval && (clearInterval(this.s.scrollInterval), this.s.scrollInterval = null);
            !this.s.scrollInterval && d && (this.s.scrollInterval = setInterval(function () {
                if (a.windowVert) g.body.scrollTop = g.body.scrollTop + a.windowVert;
                if (a.dtVert) {
                    var c = b.dom.dtScroll[0];
                    if (a.dtVert) c.scrollTop =
                        c.scrollTop + a.dtVert
                }
            }, 20))
        }
    });
    j.defaults = {
        dataSrc: 0,
        editor: null,
        enabled: !0,
        formOptions: {},
        selector: "td:first-child",
        snapX: !1,
        update: !0
    };
    var m = e.fn.dataTable.Api;
    m.register("rowReorder()", function () {
        return this
    });
    m.register("rowReorder.enable()", function (c) {
        c === n && (c = !0);
        return this.iterator("table", function (b) {
            b.rowreorder && (b.rowreorder.c.enabled = c)
        })
    });
    m.register("rowReorder.disable()", function () {
        return this.iterator("table", function (c) {
            c.rowreorder && (c.rowreorder.c.enabled = !1)
        })
    });
    j.version = "1.2.0";
    e.fn.dataTable.RowReorder = j;
    e.fn.DataTable.RowReorder = j;
    e(g).on("init.dt.dtr", function (c, b) {
        if ("dt" === c.namespace) {
            var a = b.oInit.rowReorder,
                d = l.defaults.rowReorder;
            if (a || d) d = e.extend({}, a, d), !1 !== a && new j(b, d)
        }
    });
    return j
});