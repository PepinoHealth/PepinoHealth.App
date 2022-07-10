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
        view_user_register,
        view_outpatient_outpatient,
        view_opipviews_opipreports
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
            ,{ Source.view_user_register,                   Links.Scripts.views.user.register_js }
            ,{ Source.view_outpatient_outpatient,           Links.Scripts.views.outpatient.outpatient_js}
            ,{ Source.view_opipviews_opipreports,           Links.Scripts.views.opipviews.opipviews_js}
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