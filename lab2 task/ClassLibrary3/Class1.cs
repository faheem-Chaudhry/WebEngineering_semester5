using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using ClassLibrary1;
namespace ClassLibrary3

{
    public class EmployeeRepository
    {
        List<Employee> list = new List<Employee>();
        static int count = 1;

        public void AddEmployee()
        {
            string name;
            string department;
            int salary;
            Console.WriteLine("Enter name :");
            name=Console.ReadLine();
            Console.WriteLine("Enter salary :");
            salary=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter department :");
            department=Console.ReadLine();

            Employee e = new Employee()
            {
                Name =  name,
                Salary = salary,
                Department = department,

            };
            e.Id = count;
            list.Add(e);
            count++;
        }
        public void deleteEmployee(int takeID)
        {
            foreach (Employee e in list)
            {
                if (e.Id == takeID)
                {

                    list.Remove(e);
                    break;
                }

            }
        }
        public void searchEmployee(int takeID)
        {
            foreach (Employee e in list)
            {
                if (e.Id == takeID)
                {
                    Console.WriteLine(e);
                }

            }

        }
        public void updateEmployee(int takeID)
        {
            foreach (Employee e in list)
            {
                if (e.Id == takeID)
                {
                    Console.WriteLine(e);
                    Console.WriteLine();

                    Console.WriteLine("Now enter the updated valus :");
                    Console.WriteLine("Enter new name :");
                    e.Name = Console.ReadLine();
                    Console.WriteLine("Enter new salary :");

                    e.Salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new department :");
                    e.Department = Console.ReadLine();
                }
            }
            
        }

        public void saveEmployeetoFile()
        {
            FileStream fs = new FileStream("employee.txt",FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Employee e in list)
            {
                sw.WriteLine(JsonSerializer.Serialize(e));
            }
            sw.Close();
            fs.Close();

        }
        public void displayInformation()
        {
            foreach(Employee e in list)
            {
                Console.WriteLine(
                    format: "Name of employee is {0} Salary of Employee is {1} Department is {2}",
                    arg0: e.Name,
                    arg1: e.Salary,
                    arg2: e.Department
                    );
            }
        }
        public List<Employee> readEmployeefromfile()
        {
            FileStream fs = new FileStream("employee.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line = string.Empty;
            
            List<Employee> list2 = new List<Employee>();
            while ((line == sr.ReadLine()) != null)
            {
                line = sr.ReadLine();
                //   string jsonString = fs.ReadAllText("myfile.txt")
                list2.Add(JsonSerializer.Deserialize<Employee>(line));
            }
            return list2;
        }

        public string calculateTax(int takeID, out double taxAmount)
        {
            string s = String.Empty;
            taxAmount = 0;
            foreach (Employee e in list)
            {
                if (e.Id == takeID)
                {
                    taxAmount = e.Salary * 0.15;
                                      
                }
            }
            s = "Tax amount is Rs" + taxAmount.ToString();
            return s;
        }
    }
}