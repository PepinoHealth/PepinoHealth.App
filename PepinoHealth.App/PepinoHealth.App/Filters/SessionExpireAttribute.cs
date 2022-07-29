using PepinoHealth.CL.Common;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.App.Filters
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        #region Override Methods

        /// <summary>
        /// Processes HTTP requests that fail authorization.
        /// </summary>
        /// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute"/>. The <paramref name="filterContext"/> object contains the controller, HTTP context, request context, action result, and route data.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session[Helper.SES_USER_ID] == null)
            {
                filterContext.Result = new RedirectResult(Helper.SetLogOut());

                return;
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion
    }
}