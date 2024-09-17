using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    public class UntiComparerXAndY : IComparer<Unit11>
    {
        public int Compare(Unit11 x, Unit11 y)
        {
            if ((((x.X - y.X) + (x.Y - y.Y)) * 100) > 0) return 1;
            else if ((((x.X - y.X) + (x.Y - y.Y)) * 100) < 0) return -1;
            return 0;
        }
    }
    public class UntiComparerX : IComparer<Unit11>
    {
        public int Compare(Unit11 x, Unit11 y)
        {
            if ((((x.X - y.X)) * 100) > 0) return 1;
            else if ((((x.X - y.X)) * 100) < 0) return -1;
            return 0;
        }
    }
    public class UntiComparerY : IComparer<Unit11>
    {
        public int Compare(Unit11 x, Unit11 y)
        {
            if ((((x.Y - y.Y)) * 100) > 0) return 1;
            else if ((((x.Y - y.Y)) * 100) < 0) return -1;
            return 0;
        }
    }
    public class UntiComparerXEqualY : IComparer<Unit11>
    {
        public int Compare(Unit11 x, Unit11 y)
        {
            if ((((x.X - x.Y) + (y.X - y.Y)) * 100) > 0) return 1;
            else if ((((x.X - x.Y) + (y.X - y.Y)) * 100) < 0) return -1;
            return 0;
        }
    }
    public class Unit11 : IComparable<Unit11>
    {
        public Unit11(double x, double y) 
        {
            X = x; 
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public string ToString()
        {
            return $"x:{X} \t y:{Y}";
        }

        public static List<Unit11> GenerateListPoints(int counter)
        {
            Random rnd = new Random();
            List<Unit11> list = new List<Unit11>();
            for (int i = 0; i < counter; i++) 
            {
                list.Add(new Unit11(rnd.NextDouble()*0.1, rnd.NextDouble() * 0.1));
            }
            return list;
        }

        //public int Compare(Unit11 x, Unit11 y)
        //{
        //    if ((((x.X - y.X) + (x.Y - y.Y)) * 100) > 0) return 1;
        //    else if ((((x.X - y.X) + (x.Y - y.Y)) * 100) < 0) return -1;
        //    return 0;
        //}

        public int CompareTo(Unit11 other)
        {
            return (int)(((this.X - other.X) + (this.Y - other.X)) * 100);
        }
    }
}
