using System;
using ClassLibrary1;
using System.Text.json;
using System.Text.Json.Serialization;

namespace ConsoleApp8
{
    class Program
    {
        class Pakistan
        {
            private int ag;
            public int Age
            {
                get
                {
                    return this.ag;
                }
                set
                {
                    this.ag = value;
                }
              

            }
            //public override string ToString()
            //{
            //    return ag.ToString();
            //}


            static void Main(string[] args)
            {
                Pakistan p = new Pakistan();
               
                p.Age = 12;
                int x = p.ag;
         //       Console.WriteLine(pv);
            }
        }
    }
}
