﻿using QueryExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExecutor
{
    class Program
    {

        private static DBMSSQL GetMSSQLDB()
        {
            //Private method to hold Connection String info for the database.

            //Port is an optional parameter in the DB config and is not needed for MSSQL databases.
            DBMSSQL Db = new DBMSSQL(new DbConfig("dbName", "user", "password", "host"));

            return Db;
        }

        static void Main(string[] args)
        {
            try
            {
                //Get list of students
                List<Student> Students = GetStudentInfo();

                //loop through list and display student info
                foreach (Student Student in Students)
                {
                    Console.WriteLine("First name : " + Student.FirstName + ", Last name : " + Student.LastName + ", Street Address : " + Student.StreetAddress);
                }

                //Get total number of students.
                object StudentCount = GetNumberOfStudents();
                Console.WriteLine("Total number of students : " + StudentCount.ToString());

                //Call method to create student
                CreateStudent();
                Console.WriteLine("\nNew Student Created");

                //Call method to update student records
                UpdateStudent();
                Console.WriteLine("Student updated");

                //Call method to delete student
                DeleteStudent();
                Console.WriteLine("Student deleted");
            }
            catch(System.Data.SqlClient.SqlException Ex)
            {
                Console.WriteLine(Ex.Message);
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

    }
}
