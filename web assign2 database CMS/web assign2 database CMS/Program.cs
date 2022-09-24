using System;
using System.Collections.Generic;
using System.Linq;
using classAdmin;
using ClassStudent;
using ClassTeacher;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Admin admin = new Admin();
            Student student = new Student();
            Teacher teacher = new Teacher();
            

            Console.WriteLine("*********** Welcome to CMS ***********");
            Console.WriteLine("Enter 1 for Student login");
            Console.WriteLine("Enter 2 for Instructor login");
            Console.WriteLine("Enter 3 for Admin login");

            int day;
            Console.Write("Enter value =");
            day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    if(student.studentLogin() == true)
                    {
                        student.displayStudentMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password");
                    }
                    break;

                case 2:
                    if (teacher.teacherLogin() == true)
                    {
                        teacher.displayTeacherMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password");
                    }
                    break;

                case 3:
                    if(admin.adminLogin() == true)
                    {
                        admin.displayAdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password");
                    }
                    break;

            }
        }
    }
}