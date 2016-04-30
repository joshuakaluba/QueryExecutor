/// <summary>
/// Joshua Kaluba 24-04-2016
/// </summary>

namespace QueryExecutor
{
    public class DBMySQL : ADB<MySql.Data.MySqlClient.MySqlConnection>
    {
        /// <summary>
        /// Handles the MySQLConnection
        /// </summary>
        /// <param name="Config"></param>
        public DBMySQL (DbConfig Config) : base (Config)
        {

        }
    }
}
