using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__units
{
    internal class Unit8
    {
        public Unit8()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            if (first.Length > 6 || second.Length > 6) { throw new Exception("слишком большое значение"); };

            if (first.Length < 1 || second.Length < 1) { throw new Exception("пустой ввод"); }

            bool checkF = Double.TryParse(first, out double resultF);
            bool checkS = Double.TryParse(second, out double resultS);
            if (!checkF || !checkS) { throw new Exception("числа не заданы"); }
            SaveDivision(resultF, resultS);


        }
        private static double SaveDivision(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }
    }
}
