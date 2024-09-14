using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    [CustomAtribute(21)]
    internal class Unit7
    {
        public Unit7()
        { 
            i = 0;
        }
        public Unit7(int number)
        {
            i = number;
        }
        [CustomAtribute(16)]
        public void CheckType()
        {
            Console.WriteLine("Simple txt");
        }
        public void SimpleMethod() => Console.WriteLine("Method");
        public int i;
        public int test;
        public String arr;


    }

    class CustomAtribute : System.Attribute
    {
        public int I { get; }
        public CustomAtribute() { }
        public CustomAtribute(int i) => I = i;
    }

}
