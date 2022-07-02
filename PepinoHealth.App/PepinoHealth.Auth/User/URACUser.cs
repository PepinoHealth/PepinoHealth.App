using PepinoHealth.CL.Common;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace PepinoHealth.Auth.User
{
    public class URACUser
    {
        #region Local Variable

        public List<Roles> UserRoles
        {
            get
            {
                Roles? loggedRole = GetLoggedRole();
                List<Roles> userRoles = new List<Roles>();

                if (loggedRole.HasValue)
                    userRoles.Add(loggedRole.Value);

                return userRoles;
            }
        }

        #endregion

        #region Constructors

        #endregion

        #region Common Methods

        #endregion

        #region Private Methods

        #endregion

        #region Conditional Methods

        public string GetUserName()
        {
            string userName = string.Empty;

            try
            {
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return userName;
        }

        public bool IsUserIn()
        {
            bool result = true;

            try
            {
                result = (HttpContext.Current.Session[Helper.SES_USER_IN] != null);

                if (result)
                {
                    /* IF needed, do other business operation(s). */
                }
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return result;
        }

        public bool HasAccess(params Roles[] roles)
        {
            bool result = false;

            try
            {
                Roles? loggedRole = GetLoggedRole();

                if (loggedRole.HasValue)
                {
                    result = roles.Contains(loggedRole.Value);
                }
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return result;
        }

        public Roles? GetLoggedRole()
        {
            Roles? loggedRoleID = null;

            try
            {
                if (HttpContext.Current.Session[Helper.CHE_LOGGED_ROLE] != null)
                {
                    loggedRoleID = (Roles)HttpContext.Current.Session[Helper.CHE_LOGGED_ROLE];
                }
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return loggedRoleID;
        }

        #endregion
    }
}
