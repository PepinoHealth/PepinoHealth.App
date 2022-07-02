using PepinoHealth.CL.Common;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.App.Filters
{
    public class NoAuthAttribute : ActionFilterAttribute
    {
        #region Constructors

        public NoAuthAttribute(string view)
        {
            View = view;
        }

        #endregion

        #region Local Variable Declaretion

        private string View { get; set; }

        #endregion

        #region Override Methods

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (HttpContext.Current.Response != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect(Helper.GetRedirectUrl(View));

                return;
            }
            else
            {
                base.OnResultExecuting(filterContext);
            }
        }

        #endregion
    }
}