using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClassStudent
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Batch { get; set; }
        public int semesterDues { get; set; }
        public int currentSemester { get; set; }
        public int val;
       // val = dr.GetInt32(0);

        public bool studentLogin()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);

            Console.WriteLine("*************STUDENT LOGIN******************");
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine();
            con.Open();
            string query = $"select * from StudentLogin " +
                $"where Username = @u and Password = @p";

            SqlParameter P1 = new SqlParameter("u", userName);
            SqlParameter P2 = new SqlParameter("p", pwd);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(P1);
            cmd.Parameters.Add(P2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[1].ToString() == userName || dr[2].ToString() == pwd)
                {
                    val = dr.GetInt32(0);
                }
            }
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            
           
            con.Close();
        }
        public void displayStudentMenu()
        {
            Console.WriteLine("Enter 1 for pay semester dues");
            Console.WriteLine("Enter 2 to view enrolled courses");
            Console.WriteLine("Enter 3 to view attendence");
            Console.WriteLine("Exit");
            int day;
            Console.Write("Enter value : ");
            day=Convert.ToInt32(Console.ReadLine()); 
            switch(day)
            {
                case 1:
                    paySemesterDues();
                    break;
                case 2:
                    viewCourseEnrolled();
                    break;
            }

        }
        public void paySemesterDues()
        {
            int oldAmount = 0;
            int fee;
            int updatedAmount;
            Console.Write("Enter amount of fee you want to pay :");
            fee=Convert.ToInt32(Console.ReadLine());
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [StudentInfo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(dr.GetInt32(0) == val)
                {
                    oldAmount = dr.GetInt32(4);
                }
            }
            con.Close();

            updatedAmount = oldAmount - fee;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query2 = $"update [StudentInfo] set SemesterDues = '{updatedAmount}' where Id  = '{val}'";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            int insertedRows = cmd2.ExecuteNonQuery();


            if (insertedRows >= 1)
            {
                Console.WriteLine("row inserted");

            }
            else
            {
                Console.WriteLine("failed");

            }
            con2.Close();

        }
        public void viewCourseEnrolled()
        {
            List<int> value = new List<int>();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [StudentCourse]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(2) == val)
                {
                    value.Add(dr.GetInt32(1));
                }
            }
            con.Close();

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query2 = $"select * from [Course]";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
               foreach(int i in value)
                {
                    if(i == dr2.GetInt32(0))
                    {
                        Console.WriteLine($"Course name : {dr2.GetValue(1)}");

                    }
                }
            }
            con2.Close();
        }
    }
}
