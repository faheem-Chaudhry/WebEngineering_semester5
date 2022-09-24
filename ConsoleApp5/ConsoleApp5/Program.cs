using System;

namespace ConsoleApp5
{
    class Program
    {
        static void getTable(int X, int N)
        {
            for(int i=1 ; i<=N ; i++)
            {
                Console.WriteLine(X+" * " +i+ " = " + X * i);
            }
        }
        static void Main(string[] args)
        {
            getTable(2, 10);
        }
    }
}
