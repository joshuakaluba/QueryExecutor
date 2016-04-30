/// <summary>
/// Joshua Kaluba 24-04-2016
/// </summary>
/// 
namespace QueryExecutor
{
    public class DBMSQL : ADB<System.Data.SqlClient.SqlConnection>
    {
        /// <summary>
        /// For the MSSQLConnection
        /// </summary>
        public DBMSQL(DbConfig Config) : base(Config)
        {

        }
    }
}
