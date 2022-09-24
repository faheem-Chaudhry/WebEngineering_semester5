using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public int bakr = 22;
        public string sami = "sami";

        public override string ToString()
        {
            return $"{ bakr}     {sami}";
        }
    }
}
