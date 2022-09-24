using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set ; }
        public int Salary { get; set; }

        public string Department { get; set; }

        public readonly int taxPercentage;
        

        public override string ToString()
        {
            return $"Id = {Id} Name = {Name} Salary = {Salary} Department = {Department}";
        }
    }

   
}
