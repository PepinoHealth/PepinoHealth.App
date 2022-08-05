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

    public enum ActionType
    {
        Save = 1,
        Refresh = 2,
        Print = 3,
        SaveAndPrint = 4,
        Modify = 5,
        Delete = 6,
        Popup=7
    }

    public enum OperationType
    {
        Add = 1,
        Remove = 2
    }

    #endregion
}
