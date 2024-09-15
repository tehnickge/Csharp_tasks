using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    [Serializable]
    public class Buyer
    {   
        public Buyer(string name, string address, double discount) 
        {
            Name = name;
            Address = address;
            Discount = discount;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Discount { get; set; }

    }
    [Serializable]
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name; 
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    [Serializable]
    public class  BD 
    { 
        public BD() 
        {
            ProductInfo = new Dictionary<Product, string>();
        }
        public BD(Dictionary<Product, string> map)
        {
            ProductInfo = map;
        }
        public Dictionary<Product, string> ProductInfo { get; set; }
        public void addProduct(Product product, string description)
        {
            ProductInfo.Add(product, description);
        }


    }
    [Serializable]
    public class OrderLine
    {
        public OrderLine(Product product, int amount) 
        {
            Amount = amount;
            Product = product;
        }
        public int Amount { get; set; }
        public Product Product { get; set; }
    }
    [Serializable]
    public class Order
    {
        public Order(int orderNumber, Buyer buyer, List<OrderLine> orders)
        {
            OrderNumber = orderNumber;
            Buyer = buyer;
            Lines = orders;
            Cost = GetCost(orders, buyer);
        }

        public decimal Discount { get; set; }
        public int OrderNumber {  get; set; }
        public Buyer Buyer { get; set; }
        public decimal Cost {  get; set; }
        public List<OrderLine> Lines { get; set; }
        private decimal GetCost(List<OrderLine> lines, Buyer buyer)
        {
            Discount = (decimal)buyer.Discount;
            decimal cost = 0;
            foreach(OrderLine line in Lines) 
            { 
                cost += line.Amount * line.Product.Price;
            }
            return cost - (cost * (Discount / 100));
        }

        public static string ToJSON(Order order)
        {
            string json = JsonConvert.SerializeObject(order);
            return json;
        }
        public static void WriteFile(string str, string filePath)
        {
            FileInfo fileInf = new FileInfo(filePath);
            File.WriteAllText(filePath, str);
        }
        public static List<(string, string)> StringParser(List<string> list) 
        {
            var objectList = new List<(string, string)>();

            foreach (string str in list)
            {
                string first = "1";
                string second = "1";
                objectList.Add((first, second));
            }
            return (objectList);
        }
    }

}
