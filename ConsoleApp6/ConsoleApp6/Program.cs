using System;

namespace ConsoleApp6
{
    class Program
    {
        static void sendEmail(string messege, string cc, bool attachment, string to)
        {
            Console.WriteLine(messege);
            Console.WriteLine(cc);
            Console.WriteLine($"Pakistan zindabad"+ attachment);
            Console.WriteLine(to);



        }
        static void Main(string[] args)
        {
            sendEmail("This is messege", "to", false, "fk");
        }
    }
}
