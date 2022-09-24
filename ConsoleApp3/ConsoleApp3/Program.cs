using System;
//using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void calculateGPA(params int[] Num)
        {
            var sum = 0;
           // foreach (var i  in Num)
            for(var i=0 ; i<Num.Length ; i++)
            {
               sum = Num[i] + sum;
                if (i == Num.Length-1 )
                {
                    Console.WriteLine("The GPA is = " + sum / (i+1));
                }

            }
        }

            static void Main(string[] args)
            {

                calculateGPA(10 ,20);
                calculateGPA(10, 20,30,40);



            }




    }
}
