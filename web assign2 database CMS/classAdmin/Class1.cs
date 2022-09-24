using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ClassStudent;
using ClassTeacher;
using Course;

namespace classAdmin
{
    public class Admin
    {
        public bool adminLogin()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);

            Console.WriteLine("*************ADMIN LOGIN******************");
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine();
            con.Open();
            string query = $"select * from AdminLogin " +
                $"where userName = @u and Password = @p";

            SqlParameter P1 = new SqlParameter("u", userName);
            SqlParameter P2 = new SqlParameter("p", pwd);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(P1);
            cmd.Parameters.Add(P2);
            SqlDataReader dr = cmd.ExecuteReader();

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
        public void displayAdminMenu()
        {
            Console.WriteLine("*********** Welcome to ADMIN_MENU ***********");
            Console.WriteLine("Enter 1 for Manage Students");
            Console.WriteLine("Enter 2 for Manage Teachers");
            Console.WriteLine("Enter 3 for Manage Courses");
            Console.WriteLine("Enter 4 for Exit");
            int day;
            Console.Write("Enter value =");
            day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    ManageStudent();
                    break;
                case 2:
                    ManageTeacher();
                    break;
                case 3:
                    ManageCourse();
                    break;
            }

        }
        public void ManageStudent()
        {
            Console.WriteLine("*********** Welcome to ADMIN_MENU ***********");
            Console.WriteLine("Enter 1 for Add Students");
            Console.WriteLine("Enter 2 for Update Student");
            Console.WriteLine("Enter 3 for Delete Student");
            Console.WriteLine("Enter 4 for View all Students");
            Console.WriteLine("Enter 5 to Display Outstanding Semester Dues");
            Console.WriteLine("Enter 6 to assign course toStudent");

            int day;
            Console.Write("Enter value =");
            day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    string name;
                    Console.Write("enter name = ");
                    name = Console.ReadLine();

                    string rollNo;
                    Console.Write("enter rollNo = ");
                    rollNo = Console.ReadLine();
                    Console.Write("enter Batch = ");
                    string batch;
                    batch = Console.ReadLine();
                    
                    int semesterdues;
                    Console.Write("enter SemesterDues = ");
                    semesterdues = Convert.ToInt32(Console.ReadLine());
                    Console.Write("enter current Semester = ");
                    int currentSem;
                    currentSem = Convert.ToInt32(Console.ReadLine());
                    Student student = new Student()
                    {
                        Name = name,
                        RollNo = rollNo,
                        semesterDues = semesterdues,
                        Batch = batch,
                        currentSemester = currentSem
                    };
                    Addstudent(student);
                    break;
                case 2:
                    int id;
                    Console.Write("Enter the id you want to update : ");
                    id=Convert.ToInt32(Console.ReadLine());
                    UpdateStudent(id);
                    break;
                case 3:
                    int id2;
                    Console.Write("Enter the id you want to delete : ");
                    id2 = Convert.ToInt32(Console.ReadLine());
                    deleteStudent(id2);
                    break;
                case 4:
                    viewAllStudents();
                    break;
                case 5:
                    outstandingDues();
                    break;
                case 6:
                    int id3;
                    Console.Write("Enter the id of student you want to add course : ");
                    id3 = Convert.ToInt32(Console.ReadLine());
                    AssignCourse(id3);
                    break;

            }

        }
        public void ManageTeacher()
        {
            Console.WriteLine("*********** Welcome to ADMIN_MENU ***********");
            Console.WriteLine("Enter 1 for Add Teacher");
            Console.WriteLine("Enter 2 for Update Teacher");
            Console.WriteLine("Enter 3 for Delete Teacher");
            Console.WriteLine("Enter 4 for View all Teachers");
            Console.WriteLine("Enter 5 for assign course to Teachers");

            int day;
            Console.Write("Enter value =");
            day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    string name;
                    Console.Write("enter name = ");
                    name = Console.ReadLine();

                    string experience;
                    Console.Write("enter experience = ");
                    experience = Console.ReadLine();

                    Console.Write("enter Salary = ");
                    int salary;
                    salary = Convert.ToInt32(Console.ReadLine());

                    Console.Write("enter No. of assigned courses = ");
                    int courses;
                    courses = Convert.ToInt32(Console.ReadLine());

                    
                    Teacher teacher = new Teacher()
                    {
                        Name = name,
                        Salary = salary,
                        Experience = experience,
                        AssignCourses = courses
                    };
                    Addteacher(teacher);
                    break;
                case 2:
                    int id;
                    Console.Write("Enter the id you want to update : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    UpdateTeacher(id);
                    break;
                case 3:
                    int id2;
                    Console.Write("Enter the id you want to delete : ");
                    id2 = Convert.ToInt32(Console.ReadLine());
                    deleteTeacher(id2);
                    break;
                case 4:
                    viewAllTeachers();
                    break;
                case 5:
                    int id3;
                    Console.Write("Enter the id of teacher you want to assign course : ");
                    id3 = Convert.ToInt32(Console.ReadLine());
                    AssignCourseTeacher(id3);
                    break;
            }

        }
        public void ManageCourse()
        {
            Console.WriteLine("*********** Welcome to ADMIN_MENU ***********");
            Console.WriteLine("Enter 1 for Add Course");
            Console.WriteLine("Enter 2 for Update Course");
            Console.WriteLine("Enter 3 for Delete Course");
            Console.WriteLine("Enter 4 for View all Course");
            int day;
            Console.Write("Enter value =");
            day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("***********ADD COURSE**************");
                    string Cname;
                    Console.Write("enter course Name = ");
                    Cname = Console.ReadLine();

                    Console.Write("enter credit hours = ");
                    int time;
                    time = Convert.ToInt32(Console.ReadLine());
                    course c = new course()
                    {
                        courseName = Cname,
                        creditHours = time,
                    };
                    Addcourse(c);
                    break;
                case 2:
                    int id;
                    Console.Write("Enter the id you want to update : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    UpdateCourse(id);
                    break;
                case 3:
                    int id2;
                    Console.Write("Enter the id you want to delete : ");
                    id2 = Convert.ToInt32(Console.ReadLine());
                    deleteCourse(id2);
                    break;
                case 4:
                    viewAllCourses();
                    break;
            }
                

        }
        public void Addcourse(course c)
        {
            

            string coString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con3 = new SqlConnection(coString);
            con3.Open();
            string query2 = $"Insert into [Course] (courseName, creditHours) values ('{c.courseName}','{c.creditHours}')";
            SqlCommand cmd3 = new SqlCommand(query2, con3);
            cmd3.ExecuteNonQuery();

            con3.Close();
        }
        public void UpdateCourse(int takeID)
        {
            Console.WriteLine("***********Update Course**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Course]";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == takeID.ToString())
                {
                    Console.WriteLine("Your required search for id is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, CourseName: {dr[1]}, Credit Hours: {dr[2]}");
                }
            }
            con.Close();
            Console.WriteLine("Now enter the entities you want to update");
            Console.WriteLine("1.  Add updated  Coursename");
            Console.WriteLine("2.  Add updated Credit Hours");
            int date;
            Console.WriteLine("Enter value : ");
            date = Convert.ToInt32(Console.ReadLine());

            con.Open();
            switch (date)
            {
                case 1:
                    string name;
                    Console.WriteLine("Enter updated Cname :");
                    name = Console.ReadLine();
                    string query1 = $"update [Corse] set courseName = '{name}' where courseID  = '{takeID}'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    break;

                case 2:
                    int credithours;
                    Console.WriteLine("Enter updated credit hours :");
                    credithours = Convert.ToInt32(Console.ReadLine());
                    string query2 = $"update [Course] set creditHours = '{credithours}' where courseID  = '{takeID}'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    break;                
            }
            con.Close();
        }
        public void deleteCourse(int takeID)
        {
            Console.WriteLine("***********DELETE Course**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"delete from  [Course] where courseID  = '{takeID}'";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted in course table");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();
        }
        public void viewAllCourses()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Course]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, CourseName: {dr[1]}, Credit Hours: {dr[2]}");

            }
            con.Close();
        }










        //************************************************************STUDENT******************************
        public void Addstudent(Student s)
        {
            //firstly you have to generate username and password for student you add.
            Console.WriteLine("***********ADD STUDENT**************");

            string Username;
            Console.Write("enter Username = ");
            Username = Console.ReadLine();
            string Password;
            Console.Write("enter Password = ");
            Password = Console.ReadLine();

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"Insert into [StudentLogin] (Username, Password) values ('{Username}','{Password}')";

            SqlCommand cmd = new SqlCommand(query, con);


            int insertedRows = cmd.ExecuteNonQuery();


            if (insertedRows >= 1)
            {
                Console.WriteLine("row inserted");

            }
            else
            {
                Console.WriteLine("failed");

            }
            con.Close();
            int val = 0;

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query1 = $"SELECT * FROM StudentLogin WHERE Username='{Username}'";
            SqlCommand cmd2 = new SqlCommand(query1, con2);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                val = dr.GetInt32(0);
            }
            con2.Close();

            string coString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con3 = new SqlConnection(coString);
            con3.Open();
            string query2 = $"Insert into [StudentInfo] (Id, Name, RollNo, Batch, SemesterDues, CurrentSemester) values ('{val}','{s.Name}','{s.RollNo}','{s.Batch}','{s.semesterDues}','{s.currentSemester}')";
            SqlCommand cmd3 = new SqlCommand(query2, con3);
            cmd3.ExecuteNonQuery();

            con3.Close();
        }

        public void UpdateStudent(int takeID)
        {
            Console.WriteLine("***********Update STUDENT**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [StudentInfo]";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == takeID.ToString())
                {
                    Console.WriteLine("Your required search for id is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, RollNo: {dr[2]}, Batch: {dr[3]}, Semester Dues: {dr[4]}, Current Semester: {dr[5]}");
                }
            }
            con.Close();
            Console.WriteLine("Now enter the entities you want to update");
            Console.WriteLine("1.  Add updated  name");
            Console.WriteLine("2.  Add updated RollNo");
            Console.WriteLine("3.  Add updated SemesterDues");
            int date;
            Console.WriteLine("Enter value : ");
            date = Convert.ToInt32(Console.ReadLine());

            con.Open();
            switch (date)
            {
                case 1:
                    string name;
                    Console.WriteLine("Enter updated name :");
                    name = Console.ReadLine();
                    string query1 = $"update [StudentInfo] set Name = '{name}' where Id  = '{takeID}'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    break;

                case 2:
                    string rolllNo;
                    Console.WriteLine("Enter updated RollNo :");
                    rolllNo = Console.ReadLine();
                    string query2 = $"update [StudentInfo] set RollNo = '{rolllNo}' where Id  = '{takeID}'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    break;

                case 3:
                    int dues;
                    Console.WriteLine("Enter updated SemesterDues :");
                    dues = Convert.ToInt32(Console.ReadLine());
                    string query3 = $"update [StudentInfo] set SemesterDues = '{dues}' where Id  = '{takeID}'";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    int insertedRows = cmd3.ExecuteNonQuery();
                    break;
            }
            con.Close();
        }
        public void deleteStudent(int takeID)
        {
            Console.WriteLine("***********DELETE STUDENT**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"delete from  [StudentInfo] where Id  = '{takeID}'";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted in info table");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();
            SqlConnection con2 = new SqlConnection(connString);
            con.Open();
            string query2 = $"delete from  [StudentLogin] where Sid  = '{takeID}'";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            int insertedRow = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted inlogin table");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();

        }
        public void viewAllStudents()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [StudentInfo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, RollNo: {dr[2]}, Batch: {dr[3]}, Semester Dues: {dr[4]}, Current Semester: {dr[5]}");

            }
            con.Close();
        }
        public void AssignCourse(int takeID)
        {
            Console.WriteLine("Availabe courses are. . .");
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Course]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, CourseName: {dr[1]}, Credit Hours: {dr[2]}");

            }
            
            con.Close();

            Console.WriteLine("Enter the course id you want to add from above list");
            int courseID;
            courseID = Convert.ToInt32(Console.ReadLine());

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query2 = $"Insert into [StudentCourse] (Cid, Sid) values ('{courseID}','{takeID}')";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.ExecuteNonQuery();
            con2.Close();

        }
        public void outstandingDues()
        {
            Console.WriteLine("The students whos fee is pending are : ");
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [StudentInfo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.GetInt32(4) != 0)
                {
                    Console.WriteLine($" Name: {dr[1]}, RollNo: {dr[2]},  Pending Dues: {dr[4]}");
                }

            }
            con.Close();
        }





        //**********************************************************TEACHER*****************************




        public void Addteacher(Teacher s)
        {
            //firstly you have to generate username and password for teacher you add.
            Console.WriteLine("***********ADD Teacher**************");

            string Username;
            Console.Write("enter Username = ");
            Username = Console.ReadLine();
            string Password;
            Console.Write("enter Password = ");
            Password = Console.ReadLine();

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"Insert into [TeacherLogin] (Username, Password) values ('{Username}','{Password}')";

            SqlCommand cmd = new SqlCommand(query, con);


            int insertedRows = cmd.ExecuteNonQuery();


            if (insertedRows >= 1)
            {
                Console.WriteLine("row inserted");

            }
            else
            {
                Console.WriteLine("failed");

            }
            con.Close();
            int val = 0;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query1 = $"SELECT * FROM TeacherLogin WHERE Username='{Username}'";
            SqlCommand cmd2 = new SqlCommand(query1, con2);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                val = dr.GetInt32(0);
                Console.WriteLine(val);
            }
            con2.Close();

            string coString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con3 = new SqlConnection(coString);
            con3.Open();
            string query2 = $"Insert into [TeacherInfo] (Id, Name, Salary, Experience, AssignCourses) values ('{val}','{s.Name}','{s.Salary}','{s.Experience}','{s.AssignCourses}')";
            SqlCommand cmd3 = new SqlCommand(query2, con3);
            cmd3.ExecuteNonQuery();

            con3.Close();
        }
        public void UpdateTeacher(int takeID)
        {
            Console.WriteLine("***********Update Teacher**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [TeacherInfo]";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == takeID.ToString())
                {
                    Console.WriteLine("Your required search for id is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Salary: {dr[2]}, Experience: {dr[3]}, AssignCourses: {dr[4]}");
                }
            }
            con.Close();
            Console.WriteLine("Now enter the entities you want to update");
            Console.WriteLine("1.  Add updated  Salary");
            Console.WriteLine("2.  Add updated Experience");
            Console.WriteLine("3.  Add updated AssignCourses");
            int date;
            Console.WriteLine("Enter value : ");
            date = Convert.ToInt32(Console.ReadLine());

            con.Open();
            switch (date)
            {
                case 1:
                    int salary;
                    Console.WriteLine("Enter updated salary :");
                    salary = Convert.ToInt32(Console.ReadLine());
                    string query1 = $"update [TeacherInfo] set Salary = '{salary}' where Id  = '{takeID}'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    break;

                case 2:
                    string exp;
                    Console.WriteLine("Enter updated Experience :");
                    exp = Console.ReadLine();
                    string query2 = $"update [TeacherInfo] set Experience = '{exp}' where Id  = '{takeID}'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    break;

                case 3:
                    int assigncorse;
                    Console.WriteLine("Enter updated Assigncourses :");
                    assigncorse = Convert.ToInt32(Console.ReadLine());
                    string query3 = $"update [TeacherInfo] set AssignCourses = '{assigncorse}' where Id  = '{takeID}'";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    int insertedRows = cmd3.ExecuteNonQuery();
                    break;
            }
            con.Close();
        }
        public void deleteTeacher(int takeID)
        {
            Console.WriteLine("***********delete Teacher**************");

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"delete from  [TeacherInfo] where Id  = '{takeID}'";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted in info table");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();
            SqlConnection con2 = new SqlConnection(connString);
            con.Open();
            string query2 = $"delete from  [TeacherLogin] where Id  = '{takeID}'";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            int insertedRow = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted inlogin table");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();

        }
        public void viewAllTeachers()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [TeacherInfo]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Salary: {dr[2]}, Experience: {dr[3]}, AssignCourses: {dr[4]}");

            }
            con.Close();
        }
        public void AssignCourseTeacher(int takeID)
        {
            Console.WriteLine("Availabe courses are. . .");
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Course]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, CourseName: {dr[1]}, Credit Hours: {dr[2]}");

            }

            con.Close();

            Console.WriteLine("Enter the course id you want to add from above list");
            int courseID;
            courseID = Convert.ToInt32(Console.ReadLine());

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con2 = new SqlConnection(conString);
            con2.Open();
            string query2 = $"Insert into [TeacherCourse] (Cid, Tid) values ('{courseID}','{takeID}')";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.ExecuteNonQuery();
            con2.Close();

        }
    }
}


