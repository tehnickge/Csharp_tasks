using C_units;
using Newtonsoft.Json;
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
                    Unit2 unit2 = new Unit2(5, 5, 2);
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
                    Unit6 unit6 = new Unit6(5, 10);
                    unit6.mes(5, 10);
                    break;
                case 7:
                    Unit7 unit7 = new Unit7();
                    Type type = unit7.GetType();
                    var methods = type.GetMethods();
                    var fields = type.GetFields();
                    var constructurs = type.GetConstructors();
                    var atributes = type.GetCustomAttributes();
                    Console.WriteLine("Методы с атрибутами");
                    foreach (var method in methods)
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
                    try { Unit8 unit8 = new Unit8(); }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    break;
                case 9:
                    Random rnd = new Random();
                    List<Product> products = new List<Product>();
                    Dictionary<Product, string> dic = new Dictionary<Product, string>();
                    BD bd = new BD(dic);
                    List<OrderLine> orderLines = new List<OrderLine>();
                    Buyer buyer = new Buyer("Krot","nora",rnd.NextDouble() * 24);
                    for (int i = 0; i < 10; i++)
                    {
                        products.Add(new Product($"Product{i}", i * 50));
                        dic.Add(products[i], $"price {products[i].Price} name {products[i].Name}");
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        orderLines.Add(new OrderLine(products[i], rnd.Next(24) + 1));
                    }
                    Order order = new Order(1, buyer, orderLines);

                    Console.WriteLine(buyer.Discount);
                    Console.WriteLine($"Cost: {order.Cost}, id{order.OrderNumber}, {order.Buyer.Name}, {order.Discount}%");
                    foreach(var line in order.Lines)
                    { Console.WriteLine($"c {line.Amount}, p {line.Product.Name}, totalPrice: {line.Product.Price * line.Amount}"); }
                    var json = Order.ToJSON(order);
                    var path = "C:\\Users\\Tehnick\\source\\repos\\C#_units\\C#_units\\json.json";
                    Order.WriteFile(json, path);
                    break;
                case 10:
                    string filePath = "C:\\Users\\Tehnick\\source\\repos\\C#_units\\C#_units\\Products.txt";
                    List<string> fileStrings = Unit10.ReadFileOrMake(filePath);
                    var stirngs =  Unit10.StringParser(fileStrings);
                    List<Unit10> units = new List<Unit10>();
                    foreach (var str in stirngs)
                    {
                        try
                        { 
                            units.Add(new Unit10(str.Item1, str.Item2));
                        } 
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    foreach (var unit in units)
                    {
                        Console.WriteLine($"count: {unit.Weight}, sc: {unit.SWeight}, title: {unit.Title}");
                    }
                    units.Sort();
                    Console.WriteLine("=============");
                    foreach (var unit in units)
                    {
                        Console.WriteLine($"count: {unit.Weight}, sc: {unit.SWeight}, title: {unit.Title}");
                    }
                    break;
                case 11:
                    List<Unit11> listUnit11 =  Unit11.GenerateListPoints(20);
                    foreach(var unit in listUnit11)
                    {
                        Console.WriteLine(unit.ToString());
                    }
                    listUnit11.Sort(new UntiComparerXAndY());
                    Console.WriteLine("------------XAndY------------");
                    foreach (var unit in listUnit11)
                    {
                        Console.WriteLine(unit.ToString());
                    }
                    Console.WriteLine("--------------X-----------");
                    listUnit11.Sort(new UntiComparerX());
                    foreach (var unit in listUnit11)
                    {
                        Console.WriteLine(unit.ToString());
                    }
                    Console.WriteLine("--------------Y-----------");
                    listUnit11.Sort(new UntiComparerY());
                    foreach (var unit in listUnit11)
                    {
                        Console.WriteLine(unit.ToString());
                    }
                    Console.WriteLine("-------------XEqualY----------");
                    listUnit11.Sort(new UntiComparerXEqualY());
                    foreach (var unit in listUnit11)
                    {
                        Console.WriteLine(unit.ToString());
                    }

                    break;
                case 12:
                    break;
                case 13:
                    HW1 hW1 = new HW1();
                    break;
                case 14:
                    break;
                case 15:
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
