using System;
using System.IO;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f1 = new FileStream("ahmad.txt", FileMode.Create);
            string s = "Pakistan zindabad";
            StreamWriter sw = new StreamWriter(f1);
            sw.WriteLine(s);
            sw.Close();
        }
    }
}
