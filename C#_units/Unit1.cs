using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace C_units
{
    internal class Unit1
    {
        public Unit1() 
        {
            Console.WriteLine("Введите текст");
            text = Console.ReadLine();
            Console.WriteLine("Введите слово для поиска");
            serchWord = Console.ReadLine();
        }
        private string text;
        private string serchWord;

        public int getCountWordInText()
        {
            int countWords = 0;
            text.Split(' ').Select(s => s == serchWord ? countWords++ : countWords).ToArray();
            return countWords;
        }
    }
}
