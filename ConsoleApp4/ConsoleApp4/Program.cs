using System;
using System.IO;

namespace ConsoleApp4
{
    class Program
    {
        class customer
        {
            string customer_name;
            int customer_id;
            int units;

            public void showData()
            {
                FileStream f1 = new FileStream("file.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(f1);

                Console.WriteLine("The id of customer is " + customer_id);
                sw.WriteLine("The id of customer is " + customer_id);

                Console.WriteLine("The name of customer is " + customer_name);
                sw.WriteLine("The id of customer is " + customer_name);

                Console.WriteLine("The units consumed by customer is " + units);
                sw.WriteLine("The id of customer is " + units);

            }
            public void calUnit()
            {
                float value;
                float tax;
                if(units <=199)
                {
                   value= units * 1.20f;
                    if (value <= 400)
                    {
                        Console.WriteLine("Total bill = " + value);
                    }
                    if(value > 400)
                    {
                        tax = value * 0.15f;
                        Console.WriteLine("Total bill = " + (value+tax));

                    }
                }
                if (units >= 200 && units <=400)
                {
                    value = units * 1.50f;
                    if (value <= 400)
                        Console.WriteLine("Total bill = " + value);
                    if (value > 400)
                    {
                        tax = value * 0.15f;
                        Console.WriteLine("Total bill = " + (value + tax));

                    }
                }
                if (units >= 400 && units <= 600)
                {
                    value = units * 1.50f;
                    if (value <= 400)
                        Console.WriteLine("Total bill = " + value);
                    if (value > 400)
                    {
                        tax = value * 0.15f;
                        Console.WriteLine("Total bill = " + (value + tax));

                    }
                }
                if (units >= 600)
                {
                    value = units * 2f;
                    if (value <= 400)
                        Console.WriteLine("Total bill = " + value);
                    if (value > 400)
                    {
                        tax = value * 0.15f;
                        Console.WriteLine("Total bill = " + (value + tax));

                    }
                }

               
            }

            static void Main(string[] args)
            {
                customer ali = new customer { customer_id = 1, customer_name = "Ali", units = 300 };
                ali.showData();
                ali.calUnit();
                FileStream f1 = new FileStream("file.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(f1);
            }
        }
    }
}
