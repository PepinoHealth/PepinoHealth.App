using System.Configuration;
using System.Data.SqlClient;

namespace PepinoHealth.DL.Common
{
    internal class DBConnection
    {
        internal SqlConnection AccessToSandvikApp()
        {
            SqlConnection SqlConnection = null;

            try
            {
                SqlConnection = new SqlConnection();
                SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            }
            catch (SqlException Ex)
            {

            }

            return SqlConnection;
        }
    }
}
