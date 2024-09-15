using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C_units
{
    internal class Unit10 : IComparable<Unit10>
    {
        public Unit10(string strWeight, string name)
        {
            
            decimal tempWeight;

            Decimal.TryParse(string.Join("", strWeight.Where(c => char.IsDigit(c))), out tempWeight);
            if (tempWeight <= 0) { throw new Exception("count <= 0"); }

            Title = name;
            var onlyLetters = new String(strWeight.Where(Char.IsLetter).ToArray());
            (tempWeight, onlyLetters) = ConvertToKg(tempWeight, onlyLetters);
            Weight = tempWeight;
            SWeight = onlyLetters;
        }
        public decimal Weight {  get; set; }
        public string SWeight { get; set; }
        public string Title { get; set; }
        public static List<string> ReadFileOrMake(string path)
        {
            List<string> list = new List<string>();
            foreach(var str in File.ReadAllLines(path))
            {  
                list.Add(str); 
            }
            return list;
        }
        public static List<(string, string)> StringParser(List<string> list)
        {
            var objectList = new List<(string, string)>();
            foreach (string str in list)
            {
                string first = str.Substring(0, str.IndexOf(' '));
                string second = str.Substring(str.IndexOf(' ') + 1, str.Length - str.IndexOf(' ') - 1);
                objectList.Add((first, second));

            }
            return objectList;
        }
        public static List<Unit10> Sort(List<Unit10> list)
        {
            return list;
        }
        public static (decimal, string) ConvertToKg(decimal count, string type)
        {
            switch (type)
            {
                case "кг":
                    type = "кг";
                    return (count,type);
                case "г":
                    type = "кг";
                    return (count / 1000, type);
                case "т":
                    type = "кг";
                    return (count * 1000, type);
                case "л":
                    type = "кг";
                    return (count, type);
            }
            
            return (count, type);
        }
        public int CompareTo(Unit10 other)
        {
            return Decimal.ToInt32(this.Weight - other.Weight);
        }
    }
}
