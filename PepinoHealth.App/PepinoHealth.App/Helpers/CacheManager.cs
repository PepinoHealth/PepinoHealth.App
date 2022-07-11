using PepinoHealth.CL.Common;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.App.Helpers
{
    public enum Source
    {
        bootstrap,
        bootstrap_validator,
        bootstrap_datetimepicker,
        chart,
        datatable_roworder,
        datatable_responsive,
        datatable_rowgroup,
        datatable_material,
        datatable_buttons_html5,
        datatable_buttons,
        datatable_jszip,
        datatable_buttons_flash,
        datatable_buttons_print,
        datatable_pdfmake,
        datatable_vfs_fonts,
        jquery_datatable,
        fnFilterClear,
        master,
        jquery,
        jquery_validate,
        jquery_validate_vsdoc,
        jquery_validate_unobtrusive,
        linq,
        modernizr,
        moment,
        popper,
        trumbowyg,
        view_common_common,
        view_opbilling_opbilling,        
        view_outpatient_outpatient,
        view_opipviews_opipreports,
        view_user_register
    }

    public static class CacheManager
    {
        #region Files Dictionary

        public static Dictionary<Source, string> Scripts = new Dictionary<Source, string>()
        {
            ///////////////////////////////////////
            // ----------- bootstrap ----------- //
            ///////////////////////////////////////
             { Source.bootstrap,                            Links.Scripts.bootstrap.bootstrap_js }
            ,{ Source.bootstrap_validator,                  Links.Scripts.bootstrap.bootstrap_validator.bootstrap_validator_js }
            ,{ Source.bootstrap_datetimepicker,             Links.Scripts.bootstrap.bootstrap_datetimepicker.bootstrap_datetimepicker_js }

            ///////////////////////////////////////////////////
            // ------------------- chart ------------------- //
            ///////////////////////////////////////////////////
            ,{ Source.chart,                                Links.Scripts.chart.chart_js}

            ////////////////////////////////////////////////////////
            // ------------------- datatable -------------------- //
            ////////////////////////////////////////////////////////
            ,{ Source.jquery_datatable,                     Links.Scripts.datatable.jquery_dataTables_js }
            ,{ Source.datatable_roworder,                   Links.Scripts.datatable.dataTables_rowReorder_js }
            ,{ Source.datatable_responsive,                 Links.Scripts.datatable.dataTables_responsive_js }
            ,{ Source.datatable_rowgroup,                   Links.Scripts.datatable.dataTables_rowGroup_js }
            ,{ Source.datatable_material,                   Links.Scripts.datatable.dataTables_material_js }
            ,{ Source.datatable_buttons_html5,              Links.Scripts.datatable.buttons_html5_js }
            ,{ Source.datatable_buttons,                    Links.Scripts.datatable.dataTables_buttons_js }
            ,{ Source.datatable_jszip,                      Links.Scripts.datatable.jszip_js }
            ,{ Source.datatable_buttons_flash,              Links.Scripts.datatable.buttons_flash_js }
            ,{ Source.datatable_buttons_print,              Links.Scripts.datatable.buttons_print_js }
            ,{ Source.datatable_pdfmake,                    Links.Scripts.datatable.pdfmake_js }
            ,{ Source.datatable_vfs_fonts,                  Links.Scripts.datatable.vfs_fonts_js }
            ,{ Source.fnFilterClear,                        Links.Scripts.datatable.fnFilterClear_js }

            ///////////////////////////////////////
            // ----------- dynamic ----------- //
            ///////////////////////////////////////
            ,{ Source.master,                               Links.Scripts.dynamic.master_js }
            
            ////////////////////////////////////
            // ----------- jquery ----------- //
            ////////////////////////////////////
            ,{ Source.jquery,                               Links.Scripts.jquery.jquery_3_6_0_js }
            ,{ Source.jquery_validate,                      Links.Scripts.jquery.jquery_validate.jquery_validate_js}
            ,{ Source.jquery_validate_vsdoc,                Links.Scripts.jquery.jquery_validate_vsdoc.jquery_validate_vsdoc_js }
            ,{ Source.jquery_validate_unobtrusive,          Links.Scripts.jquery.jquery_validate_unobtrusive.jquery_validate_unobtrusive_js }

            ////////////////////////////////////
            // ----------- common ----------- //
            ////////////////////////////////////
            ,{ Source.linq,                                 Links.Scripts.linq.linq_js }
            ,{ Source.modernizr,                            Links.Scripts.modernizr.modernizr_2_8_3_js }
            ,{ Source.moment,                               Links.Scripts.moment.moment_js }
            ,{ Source.popper,                               Links.Scripts.popper.umd.popper_js }
            ,{ Source.trumbowyg,                            Links.Scripts.trumbowyg.trumbowyg_js }

            ///////////////////////////////////
            // ----------- views ----------- //
            ///////////////////////////////////
            ,{ Source.view_common_common,                   Links.Scripts.views.common.common_js }
            ,{ Source.view_opbilling_opbilling,             Links.Scripts.views.opbilling.opbilling_js }
            ,{ Source.view_outpatient_outpatient,           Links.Scripts.views.outpatient.outpatient_js}
            ,{ Source.view_opipviews_opipreports,           Links.Scripts.views.opipviews.opipviews_js}
            ,{ Source.view_user_register,                   Links.Scripts.views.user.register_js }
        };

        #endregion

        #region Custom Methods

        public static IHtmlString WriteStyleInclude(this HtmlHelper helper, string style, Async async = Async.False)
        {
            string path = Helper.GetVirtualPath(style);

            return helper.Raw(string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\" {1} />", path, (async == Async.False ? "" : "media=\"none\" onload =\"if (media != 'all') media = 'all'\"")));
        }

        public static IHtmlString WriteScriptInclude(this HtmlHelper helper, Source script, Async async = Async.False, Defer defer = Defer.False)
        {
            string path = Helper.GetVirtualPath(Scripts[script].ToString());

            return helper.Raw(string.Format("<script src=\"{0}\" type=\"text/javascript\" {1} {2}></script>", path, (async == Async.False ? "" : "async"), (defer == Defer.False ? "" : "defer")));
        }

        #endregion
    }
}