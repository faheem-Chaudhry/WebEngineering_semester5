// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using ClassLibrary3;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--------------Welcome to EMS----------");
            Console.WriteLine("1.  Add employee");
            Console.WriteLine("2.  Delete employee");
            Console.WriteLine("3.  Update employee");
            Console.WriteLine("4.  Display Tax");
            Console.WriteLine("5.  Search employee");
            Console.WriteLine("6.  Add employee to file");
            Console.WriteLine("7.  Read employee from file employee");
            Console.WriteLine("8.  Display all employee");




            EmployeeRepository employeeRepository = new EmployeeRepository();
            int day;
            int id;
            char c;
            do
            {
                Console.WriteLine("Enter value :");
                day = Convert.ToInt32(Console.ReadLine());
                switch (day)
                {
                    case 1:
                        Console.WriteLine("------- Add Employee ---------");
                        employeeRepository.AddEmployee();
                        break;

                    case 2:
                        Console.WriteLine("Enter id to delete employee : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        employeeRepository.deleteEmployee(id);
                        break;

                    case 3:
                        Console.WriteLine("Enter id to update employee : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        employeeRepository.updateEmployee(id);
                        break;

                    case 4:
                        double taxAmount;
                        Console.WriteLine("Enter id to calculate Tax Amount : ");
                        id = Convert.ToInt32(Console.ReadLine());                        
                        Console.WriteLine(employeeRepository.calculateTax(id, out taxAmount));
                        break;

                    case 5:
                        Console.WriteLine("Enter id to search employee : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        employeeRepository.searchEmployee(id);
                        break;

                    case 6:
                        employeeRepository.saveEmployeetoFile();
                        Console.WriteLine("Employee save to file successfully");
                        break;

                    case 7:
                        Console.WriteLine("Enter id to delete employee : ");
                        break;


                    case 8:
                        Console.WriteLine("Display Information");
                        employeeRepository.displayInformation();
                        break;

                    default:
                        Console.WriteLine("You enter in valid input");
                        break;

                }
                Console.WriteLine("Enter Y or y if you want to quit otherwise enter any key to continue :");
                c = char.Parse(Console.ReadLine());
                if(c != 'y' || c != 'Y')
                {
                    break;
                }

            } while(true);
        }
    }
}
