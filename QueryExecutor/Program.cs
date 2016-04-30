using QueryExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> Students = GetStudentInfo();

            foreach (Student Student in Students)
            {
                Console.WriteLine("First name : " + Student.FirstName + ", Last name : " + Student.LastName + ", Street Address : " + Student.StreetAddress);
            }


            object StudentCount = GetNumberOfStudents();
            Console.WriteLine("Total number of students : " + StudentCount.ToString());


            Console.Read();
        }

        public static object GetNumberOfStudents()
        {
            //Get db connection string
            DBMSSQL Db = GetMSSQLDB();

            //Declare the scalar query
            String Query = "Select COUNT(*) FROM Student;";


            object StudentCount = Db.Scalar(Query);
            return StudentCount;
        }

        public static List<Student> GetStudentInfo()
        {
            //Get db connection string
            DBMSSQL Db = GetMSSQLDB();

            //Declare the query
            String Query = "SELECT LastName, FirstName, StreetAddress from Student;";

            //Execute the query and store the query results from the database in a list
            List<Student> Students = new List<Student>(Db.Query<Student>(Query));

            //return results
            return Students;
            
        }

        private static DBMSSQL GetMSSQLDB()
        {
            //Private method to hold connection string info for the database

            //Port is an optional parameter in the DB config and is not needed for MSSQL databases.
            DBMSSQL Db = new DBMSSQL(new DbConfig("adminkaluba", "joshkal", "Guyk433%", "198.71.225.145"));
            //DBMSSQL Db = new DBMSSQL(new DbConfig("dbName", "user", "password", "host"));
            return Db;
        }
    }
}
