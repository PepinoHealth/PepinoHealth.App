using PepinoHealth.CL.Common;
using System;
using System.Web;
using System.Web.Mvc;

namespace PepinoHealth.Auth.User
{
    public static class URAC_ExtendedMethods
    {
        #region Local Variables

        private static URACUser uRACUser;

        #endregion

        #region Constructor

        static URAC_ExtendedMethods()
        {
            uRACUser = new URACUser();
        }

        #endregion

        #region Conditional Methods

        public static bool IsLogged(this ControllerBase controller)
        {
            bool result = false;

            try
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    result = true;
                }
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return result;
        }

        public static bool HasAccess(this ControllerBase controller, params Roles[] roles)
        {
            bool result = false;

            try
            {
                result = uRACUser.HasAccess(roles);
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return result;
        }

        public static IHtmlString GetPrimaryColor(this HtmlHelper helper, bool isRGB = false)
        {
            string color = uRACUser.GetPrimaryColor(isRGB);

            return helper.Raw(color);
        }

        #endregion
    }
}
