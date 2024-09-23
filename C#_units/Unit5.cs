using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    internal class Unit5
    {
        private string path = "C:\\Users\\Tehnick\\source\\repos\\C#_units\\C#_units\\F.txt";
        public Unit5() 
        {
            ReadFile();
        }
        public async void ReadFile()
        {
            Console.WriteLine("Введите номер месяца: Пример: 4 или 12");
            var month = Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists) { MakeFile(); }
            var text = File.ReadAllLines(path);
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < text.Length; i++)
            {
                dates.Add(DateTime.Parse(text[i]));
            }
            uint counter = 0;
            for (int i = 0; i < dates.Count; i++)
            {
                if (dates[i].Month == int.Parse(month))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
        public void MakeFile() 
        {
            FileInfo fileInf = new FileInfo(path);
            fileInf.Create();
        }
    }
}
