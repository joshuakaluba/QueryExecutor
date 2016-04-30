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
            try
            {
                List<Student> Students = GetStudentInfo();

                foreach (Student Student in Students)
                {
                    Console.WriteLine("First name : " + Student.FirstName + ", Last name : " + Student.LastName + ", Street Address : " + Student.StreetAddress);
                }

                object StudentCount = GetNumberOfStudents();
                Console.WriteLine("Total number of students : " + StudentCount.ToString());

                CreateStudent();
                Console.WriteLine("\nNew Student Created");

                System.Threading.Thread.Sleep(1000);

                UpdateStudent();

                Console.WriteLine("Student updated");

                System.Threading.Thread.Sleep(1000);

                DeleteStudent();

                Console.WriteLine("Student deleted");
            }
            catch(System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Unable to connect to database, make sure your connection string info is correct");
            }
            


            Console.Read();
        }

        private static void CreateStudent()
        {
            //Get db connection string.
            DBMSSQL Db = GetMSSQLDB();

            //Declare the insert statement.
            String Query = "INSERT INTO Student (LastName, FirstName, StreetAddress) Values ('Murkel','Cliff','115 Niagara Ave');";

            //Execute the query
            Db.NonQuery(Query);

        }

        private static void UpdateStudent()
        {
            //Get db connection string.
            DBMSSQL Db = GetMSSQLDB();

            //Declare the update statement.
            String Query = "UPDATE Student SET LastName = 'Peters' WHERE ID='4';";

            //Execute the query
            Db.NonQuery(Query);
        }

        private static void DeleteStudent()
        {
            //Get db connection string.
            DBMSSQL Db = GetMSSQLDB();

            //Declare the delete statement.
            String Query = "DELETE From Student WHERE ID='4';";

            //Execute the query
            Db.NonQuery(Query);

        }

        public static object GetNumberOfStudents()
        {
            //Get db connection string.
            DBMSSQL Db = GetMSSQLDB();

            //Declare the scalar query.
            String Query = "Select COUNT(*) FROM Student;";

            //Pass the query to the scalar db method and execute the query.
            object StudentCount = Db.Scalar(Query);

            //return results.
            return StudentCount;
        }

        public static List<Student> GetStudentInfo()
        {
            //Returns a list of student records.

            //Get db connection string.
            DBMSSQL Db = GetMSSQLDB();

            //Declare the query.
            String Query = "SELECT LastName, FirstName, StreetAddress from Student;";

            //Execute the query and store the query results from the database in a list.
            List<Student> Students = new List<Student>(Db.Query<Student>(Query));

            //return results.
            return Students;
            
        }

        private static DBMSSQL GetMSSQLDB()
        {
            //Private method to hold connection string info for the database.

            //Port is an optional parameter in the DB config and is not needed for MSSQL databases.
            //DBMSSQL Db = new DBMSSQL(new DbConfig("dbName", "user", "password", "host"));

            DBMSSQL Db = new DBMSSQL(new DbConfig("adminkaluba", "joshkal", "Guyk433%", "198.71.225.145"));

            return Db;
        }
    }
}
