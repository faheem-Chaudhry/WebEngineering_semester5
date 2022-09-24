using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ClassTeacher
{
    public class Teacher
    {
        public int Tid { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Experience { get; set; }
        public int AssignCourses { get; set; }

        public int val;
        public bool teacherLogin()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);

            Console.WriteLine("*************Teacher LOGIN******************");
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine();
            con.Open();
            string query = $"select * from TeacherLogin " +
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
        public void displayTeacherMenu()
        {
            Console.WriteLine("Enter 1 for mark attendence");
            Console.WriteLine("Enter 2 to post assignment");
            Console.WriteLine("Enter 3 to view assigned course");
            Console.WriteLine("Exit");
            int day;
            Console.Write("Enter value : ");
            day = Convert.ToInt32(Console.ReadLine());
            switch (day)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    viewCourseEnrolled();
                    break;

            }

        }
        public void viewCourseEnrolled()
        {
            List<int> value = new List<int>();
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [TeacherCourse]";
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
                foreach (int i in value)
                {
                    if (i == dr2.GetInt32(0))
                    {
                        Console.WriteLine($"Course name : {dr2.GetValue(1)}");

                    }
                }
            }
            con2.Close();
        }
    }
}
