using PepinoHealth.CL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace PepinoHealth.Auth.User
{
    public class URACAttribute : AuthorizeAttribute
    {
        #region Local Variable

        private readonly URACUser uRACUser;

        public new List<Roles> Roles { get; set; }

        public Roles MinRequiredRole { get; set; }

        #endregion

        #region Constructors

        public URACAttribute(params Roles[] roles)
        {
            Roles = roles.ToList();
        }

        public URACAttribute(Roles minRequiredRole)
        {
            MinRequiredRole = minRequiredRole;
        }

        #endregion              

        #region Override Methods

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "LogOut" }, { "controller", "Home" }, { "returnUrl", filterContext.HttpContext.Request.Url.AbsolutePath } });
            }
            else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var uRACUser = new URACUser();

                if (uRACUser != null)
                {
                    /* Check weather the user has atleat one role or not */
                    if (Roles != null && Roles.Count(role => uRACUser.UserRoles.Contains(role)) == 0)
                    {
                        RedirectResult(filterContext);
                    }
                    else if (MinRequiredRole != 0 && !uRACUser.UserRoles.Contains(MinRequiredRole))
                    {
                        RedirectResult(filterContext);
                    }
                }
            }
        }

        #endregion

        #region Common Methods

        private void RedirectResult(AuthorizationContext filterContext)
        {
            string redirectUrl = string.Empty;

            Roles loggedRoleID = (Roles)Helper.GetLoggedRoleID();

            switch (loggedRoleID)
            {
                case CL.Common.Roles.Admin:
                case CL.Common.Roles.User:
                    redirectUrl = Helper.QuickLinksV2;
                    break;
            }

            filterContext.Result = new RedirectResult(Helper.GetRedirectUrl(redirectUrl));
        }

        #endregion
    }
}
