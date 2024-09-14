using C__units;
using C_units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                case 6:
                    Unit6 unit6 = new Unit6(5,10);
                    unit6.mes(5,10);
                    break;
                case 7:
                    Unit7 unit7 = new Unit7();
                    Type type = unit7.GetType();
                    var methods = type.GetMethods();
                    var fields = type.GetFields();
                    var constructurs = type.GetConstructors();
                    var atributes = type.GetCustomAttributes();
                    Console.WriteLine("Методы с атрибутами");
                    foreach(var method in methods)
                    {
                        method.GetCustomAttribute(typeof(CustomAtribute));

                        if (method.GetCustomAttribute(typeof(CustomAtribute)) != null)
                        {
                            Console.WriteLine(method);
                            Console.WriteLine(((CustomAtribute)method.GetCustomAttribute(typeof(CustomAtribute))).I);
                        }
                    }
                    Console.WriteLine("_____________");
                    Console.WriteLine("Все поля класса");
                    foreach (var field in fields)
                    {

                        Console.WriteLine(field);
                    }
                    Console.WriteLine("_____________");
                    Console.WriteLine("Конструкторы");
                    foreach (var constructur in constructurs)
                    {
                        Console.WriteLine(constructur);
                    }
                    Console.WriteLine("_____________");
                    Console.WriteLine("Атрибуты класса");
                    foreach (var atribute in atributes)
                    {
                        Console.WriteLine(((CustomAtribute)atribute).I);
                        Console.WriteLine((CustomAtribute)atribute);
                    }
                    var met = type.GetMethod("CheckType");
                    Console.WriteLine("_____________");
                    Console.WriteLine("рефлекшен вызовы метода");
                    met?.Invoke(unit7, parameters: null);   
                    break;
                case 8:
                    try
                    {
                        Unit8 unit8 = new Unit8();

                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    
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
