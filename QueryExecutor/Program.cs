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
            DBMSQL Db = new DBMSQL(new DbConfig("db", "user", "pass", "host"));

            String QueryString = "SELECT LastName, FirstName, StreetAddress from Student";

            List<Student> Students = new List<Student>(Db.Query<Student>(QueryString));

            Student G = Students.Where(d => d.FirstName == "mark").FirstOrDefault();

            

            

            foreach (Student Student in Students)
            {
                Console.WriteLine(Student.FirstName + "\n");
            }
            
            Console.WriteLine(Students.Count.ToString());

            
        }
    }
}
