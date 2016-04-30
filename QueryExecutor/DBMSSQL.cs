/// <summary>
/// Joshua Kaluba 24-04-2016
/// </summary>
/// 
namespace QueryExecutor
{
    public class DBMSSQL : ADB<System.Data.SqlClient.SqlConnection>
    {
        /// <summary>
        /// For the MSSQLConnection
        /// </summary>
        public DBMSSQL(DbConfig Config) : base(Config)
        {

        }
    }
}
