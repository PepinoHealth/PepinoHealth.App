using System.ComponentModel;

namespace PepinoHealth.CL.Common
{
    #region Enum

    public enum Async
    {
        True = 1,
        False = 0
    }

    public enum Defer
    {
        True = 1,
        False = 0
    }

    public enum Roles
    {
        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }

    #endregion
}
