using System;

namespace QueryExecutor
{
    public class DbConfig
    {
       
        private String _name;
        private String _password;
        private String _host;
        private Int16 _port = 0;
        private String _db;


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

        
        public String Database
        {
            get { return _db; }
            set { _db = value; }
        }


        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public String Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public String Host
        {
            get { return this._host; }
            set { this._host = value; }
        }

        public Int16 Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        public override string ToString()
        {
            //Create formated connection string
            string _connectionString = "";
            _connectionString += "server=" + this._host + ";";
            _connectionString += "user=" + this._name + ";";
            _connectionString += "database=" + this._db + ";";

            if(this._port!=0)
            {
                //if a port has been provided. 
                _connectionString += "port=" + this._port.ToString() + ";";
            }
        
            _connectionString += "password=" + this._password + ";";
            return _connectionString;
        }
        

        
    }
}
