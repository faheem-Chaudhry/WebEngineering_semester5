using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public (string a, int b) nameAndage()
        {
            return (Name, Age);
        }

        public List<Person> ReadDataa()
        {
            List<Person> guy = new List<Person>();
            FileStream f1 = new FileStream("uj.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(",");
                Person p = new Person();
                //p.Name = data[0];
                //p.Age = Convert.ToInt32((data[1]));
                foreach( var i in data)
                {
                    Console.WriteLine(i);
                }
                guy.Add(p);
               
            }
            return guy;
        }
    }


    public class Program
    {


        public static void Main(string[] args)
        {
            int age;
            Person p = new Person();
            p.Name = "Ali";
            p.Age = 12;
            p.ReadDataa();
            //foreach(Person P1 in p.ReadDataa())
            //{
            //    Console.WriteLine(P1.Name);
            //    Console.WriteLine(P1.Age);
            //}
                    // Console.WriteLine(args[0]);

      //      age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(
                format: "{0} apples costs {1:C}",
                arg0: "Pak",
                arg1: "Ind"
                );
        }
    }
}
                


            




    
    












//using System.Text.Json;
//// See https://aka.ms/new-console-template for more information

//internal class Person
//{
//    public int Age { get; set; }
//    public string Name { get; set; }
//    public Address Address { get; set; }
//}

//    internal class Address
//    {
//        public string City { get; set; }
//        public string Country { get; set; }
//        public int ZIP { get; set; }


//        Person p = new Person
//        {
//            Name = "Ali",
//            Age = 12,
//            Address = new Address
//            {
//                City = "Lahore",
//                Country = "Pakistan",
//                ZIP = 54000
//            }
//        };
//    }


