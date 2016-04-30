/// <summary>
/// Joshua Kaluba 24-04-2016
/// </summary>

namespace QueryExecutor
{
    public class DBMySQL : ADB<MySql.Data.MySqlClient.MySqlConnection>
    {
        /// <summary>
        /// For the MySQLConnection
        /// </summary>
        
        public DBMySQL (DbConfig Config) : base (Config)
        {

        }
    }
}
