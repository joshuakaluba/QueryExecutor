using System.Collections.Generic;
using System.Data;


/// <summary>
/// Joshua Kaluba - 24-04-2016
/// </summary>

namespace QueryExecutor
{

    public abstract class ADB<DBConnection> : IDB where DBConnection : System.Data.IDbConnection, new()
    {
        System.Data.IDbConnection _conn;
        public DbConfig DbConfiguration { get; set; }

        public ADB(DbConfig Config)
        {
            this.DbConfiguration = Config;
        }
                    

        public void Open()
        {
            //This method handles opening the database connection

            if (this.DbConfiguration == null)
            {
                //Return if there is no database configuration
                return;
            }               
            else if (this._conn == null)
            {
                //Check if there is no database connection
                this._conn = new DBConnection();
                this._conn.ConnectionString = this.DbConfiguration.ToString();
            }

            if (this._conn.State == ConnectionState.Broken)
            {
                //Check if there is a broken connection
                this._conn.Close();
            }
               

            if (this._conn.State == ConnectionState.Closed)
            {
                //Check if connection has closed
                _conn.Open();
            }
                

        }       

        public void NonQuery(string Query)
        {
            //Used for Insert/Update and Deletes

            //Open a connection to the database
            this.Open();

            using (System.Data.IDbCommand command = this._conn.CreateCommand())
            {
                //Assign the command the query string and execute
                command.CommandText = Query;                
                command.ExecuteNonQuery();
            }

            //Once executed, close connection to database.
            this.Close();
        }
        
        
        public IEnumerable<ResultClass> Query<ResultClass>(string Query) 
        {
            //Used for select statements

            System.Xml.Serialization.XmlSerializer serializer;

            //Declare an array of ResultClass which is a template object
            ResultClass[] results;

            //Open a connection to the database
            this.Open();


            using (System.Data.IDbCommand command = this._conn.CreateCommand())
            {
                //Assign the command the query string
                command.CommandText = Query;


                using (System.Data.IDataReader reader = command.ExecuteReader())
                {
                    using (System.Data.DataSet set = new DataSet("output"))
                    {
                        using (System.Data.DataTable table = new DataTable())
                        {    
                            //load the DataReader                       
                            table.Load(reader);

                            set.Tables.Add(table);

                            //Set the table name to the result class, without this, the program would not be able to serialize objects that are not from only one table. E.G - Joins
                            table.TableName = typeof(ResultClass).Name;

                            using (System.IO.MemoryStream xmlStream = new System.IO.MemoryStream())
                            {
                                set.WriteXml(xmlStream);

                                //Set the start position
                                xmlStream.Position = 0;

                                System.Diagnostics.Debug.WriteLine(System.Text.Encoding.Default.GetString(xmlStream.ToArray()));
                                serializer = new System.Xml.Serialization.XmlSerializer(typeof(ResultClass[]), new System.Xml.Serialization.XmlRootAttribute("output"));
                                results = ((ResultClass[])serializer.Deserialize(xmlStream));
                            }
                        }
                    }
                }
            }

            //Close the connection to the database
            this.Close();
            return results;

        }

        public object Scalar(string Query)
        {
            //This method should handle all scalar queries such as COUNT or AVG

            //Open connection to database.
            this.Open();

            //Instantiate object to hold the result of the query.
            object result;

            using (System.Data.IDbCommand command = this._conn.CreateCommand())
            {
                command.CommandText = Query;

                //Execute the query
                result = command.ExecuteScalar();
            }

            //Close connection to database
            this.Close();

            //return result object
            return result;
        }

        public void Close()
        {
            //Closes connection to the database

            if ((this._conn != null) && (this._conn.State != ConnectionState.Closed))
            {
                _conn.Close();
            }
                
        }

    }
}
