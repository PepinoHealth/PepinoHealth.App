using PepinoHealth.CL.Common;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Drawing;
using System.Globalization;

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

        private Color GetRGB(string hexColor)
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            try
            {
                if (hexColor != null)
                {
                    if (hexColor.IndexOf('#') != -1)
                        hexColor = hexColor.Replace("#", "");

                    if (hexColor.Length == 6)
                    {
                        //#RRGGBB
                        red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                        green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                        blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
                    }
                    else if (hexColor.Length == 3)
                    {
                        //#RGB
                        red = int.Parse(hexColor[0].ToString() + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
                        green = int.Parse(hexColor[1].ToString() + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
                        blue = int.Parse(hexColor[2].ToString() + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
                    }
                }
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return Color.FromArgb(red, green, blue);
        }

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

        public string GetPrimaryColor(bool isRGB = false)
        {
            string color = string.Empty;

            try
            {
                string primaryColor = "1595CD";
                
                var rgb = GetRGB(primaryColor);

                if (isRGB)
                    color = string.Concat(rgb.R, ",", rgb.G, ",", rgb.B);
                else
                    color = primaryColor;
            }
            catch (Exception exception)
            {
                Helper.Log(exception);
            }

            return color;
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
