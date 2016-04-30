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
            DBMSSQL Db = GetMSSQLDB();
            object StudentCount = Db.Scalar("Select COUNT(*) FROM Student;");
            return StudentCount;
        }

        public static List<Student> GetStudentInfo()
        {
            DBMSSQL Db = GetMSSQLDB();

            String Query = "SELECT LastName, FirstName, StreetAddress from Student;";

            List<Student> Students = new List<Student>(Db.Query<Student>(Query));

            return Students;
            
        }

        private static DBMSSQL GetMSSQLDB()
        {
            DBMSSQL Db = new DBMSSQL(new DbConfig("dbName", "user", "password", "host"));
            return Db;
        }
    }
}
