using System;

/// <summary>
/// Joshua Kaluba 24-04-2016
/// </summary>

namespace QueryExecutor
{
    
    public class DbConfig
    {       
        public String Database { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String  Host { get; set; }
        public Int16 Port { get; set; }

        public DbConfig(String Database, String Name, String Password, String Host, Int16 Port)
        {
            this.Name = Name;
            this.Password = Password;
            this.Host = Host;
            this.Database = Database;
            this.Port = Port;
        }

        public DbConfig(String Database, String Name, String Password, String Host)
        {
            this.Name = Name;
            this.Password = Password;
            this.Host = Host;
            this.Database = Database;
        }
         

        public override string ToString()
        {
            //Create formated connection string
            String ConnectionString = "";
            ConnectionString += "server=" + this.Host+ ";";
            ConnectionString += "user=" + this.Name + ";";
            ConnectionString += "database=" + this.Database + ";";

            if(this.Port!=0)
            {
                //if a port has been provided. 
                ConnectionString += "port=" + this.Port.ToString() + ";";
            }
        
            ConnectionString += "password=" + this.Password + ";";
            return ConnectionString;
        }     

        
    }
}
