using C_units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    internal class Program
    {
        static void SelectUnit(int number) 
        {
            switch (number)
            {
                case 1:
                    Unit1 unit1 = new Unit1();
                    int value = unit1.getCountWordInText();
                    Console.WriteLine(value);
                    break; 
                case 2:
                    Unit2 unit2 = new Unit2(5,5,2);
                    break;
                case 3:
                    Factory factory = new Factory();
                    factory.AddItem("1", "jopa");
                    factory.AddPerson("Nikita", "worker");
                    factory.AddTask("add change", "any words", "22.04.2012", "ready to work", "1", "2", "jopa", factory.persons[0]);
                    factory.MakeWork();
                    break;
                case 5:
                    Unit5 unit5 = new Unit5();

                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("ввдедите номер лаболоторной работы");
            string str = Console.ReadLine();
            while (str != "exit") 
            {
                int res; int.TryParse(str, out res);
                SelectUnit(res);

                str = Console.ReadLine();
            }
        }
    }
}
