using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace PepinoHealth.CL.Common
{
    public static class Helper
    {
        #region Constants

        public const string SES_USER_ID = "UserID";
        public const string SES_USER_IN = "UserIn";

        public const string CHE_EMAIL = "Email";
        public const string CHE_LOGGED_ROLE = "LoggedRole";
        public const string CHE_LOGGED_USER = "LoggedUserInfo";

        public const string Home = "home";
        public const string DashBoard = "dashboard";
        public const string QuickLinks = "quick-links";
        public const string QuickLinksV2 = "quick-links-v2";
        public const string Registration = "registration";
        public const string RegistrationV2 = "registration-v2";
        public const string RevisitRegistration = "revisit-registration";
        public const string Login = "login";
        public const string Logout = "logout";
        //Reports
        public const string IPDPatientRegistration = "IPDPatientRegistration";
        public const string OutPatientRegistration = "OutPatientRegistration";
        public const string PatientDischarge = "PatientDischarge";
        //OPRegistration
        public const string OPRegistration = "opregistration";
        public const string OPRevisitRegistration = "oprevisitRegistration";

        public const string bindGenerateBarcode = "bindGenerateBarcode";

        public const string DateMonthFirst = "M/d/yyyy";

        public const string ApplicationName = "Pepino Health";

        public const string Master = "master";

        public const int PageCacheTimeOut = 31536000;
        public const int PostCacheTimeOut = 86400;
        public const int FormTimeOut = 20;
        public const int RememberMeTimeOut = 21600;

        #endregion

        #region App Keys


        #endregion

        #region Common Methods

        public static int GetLoggedRoleID()
        {
            int loggedRoleID = 0;

            if (HttpContext.Current.Session[CHE_LOGGED_ROLE] != null)
                loggedRoleID = (int)HttpContext.Current.Session[CHE_LOGGED_ROLE];

            return loggedRoleID;
        }

        public static string GetVirtualPath(string path, string version = "1.0")
        {
            string virtualPath = string.Empty;

            version = string.Concat("v-", version);

            int index = 0;
            var paths = path.Split('/').Skip(1).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            paths.ForEach(item =>
            {
                if (index == 1)
                {
                    stringBuilder.Append("/").Append(version);
                }

                stringBuilder.Append("/").Append(item);

                index++;
            });

            virtualPath = stringBuilder.ToString();

            return virtualPath;
        }

        public static string GetRelativePath(string path)
        {
            string relativePath = string.Empty;

            int index = 0;

            var paths = path.Replace(".css", ".less").Split('/').Skip(1).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            paths.ForEach(item =>
            {
                if (index != 1)
                    stringBuilder.Append("/").Append(item);

                index++;
            });

            relativePath = stringBuilder.ToString();

            return relativePath;
        }

        public static string GetRedirectUrl(string view)
        {
            string url = string.Empty;

            try
            {
                url = string.Concat("~/", view);
            }
            catch (Exception exception)
            {
                Log(exception);
            }

            return url;
        }

        public static string SetLogIn()
        {
            string url = string.Empty;

            try
            {
                url = GetRedirectUrl(Login);
            }
            catch (Exception exception)
            {
                Log(exception);
            }

            return url.Replace("~", string.Empty); ;
        }

        public static string SetLogOut()
        {
            string url = string.Empty;

            try
            {
                url = GetRedirectUrl(Logout);
            }
            catch (Exception exception)
            {
                Log(exception);
            }

            return url.Replace("~", string.Empty);
        }

        public static int GetRoleID(string username)
        {
            int roleID = (int)Roles.Admin;

            if (username.Equals("admin@abc.com"))
                roleID = (int)Roles.Admin;
            else if (username.Equals("user@abc.com"))
                roleID = (int)Roles.User;

            return roleID;
        }

        public static bool HasSegments()
        {
            bool result = HttpContext.Current.Request.Url.AbsolutePath.Contains("SessionHelpers") || HttpContext.Current.Request.Url.Segments.Length > 1;
            
            return result;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Session.Remove(CHE_EMAIL);
            HttpContext.Current.Session.Remove(CHE_LOGGED_USER);
        }

        #endregion

        #region Authentication Ticket Method

        public static void GrantAuthenticationTicket(string email, bool rememberMe, Dictionary<string, object> userData)
        {
            DateTime
                currrentTime = DateTime.Now,
                expiryTime = DateTime.Now.AddMinutes(rememberMe ? RememberMeTimeOut : FormTimeOut);

            string userDataJson = (userData != null ? JsonConvert.SerializeObject(userData) : string.Empty);

            /* Grant authentication ticket */
            var authTicket = new FormsAuthenticationTicket(1, email, currrentTime, expiryTime, rememberMe, userDataJson, "/");

            /* Encrypt the ticket and add it to a cookie */
            HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
            {
                Domain = FormsAuthentication.CookieDomain,
                Expires = expiryTime,
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath
            };

            /* Add authentication cookie to response */
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static void RemoveAuthenticationTicket()
        {
            // NOTE: FormsAuthentication.SignOut() cannot be used as it doesn't allow specify cookie' path
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(null, true);
            cookie.Expires = new DateTime(1999, 10, 12);
            HttpContext current = HttpContext.Current;
            current.Response.Cookies.Add(cookie);
        }

        #endregion

        #region Error Log

        public static void Log(
            Exception exception,
            string catchBlock = null)
        {

        }

        #endregion
    }
}
