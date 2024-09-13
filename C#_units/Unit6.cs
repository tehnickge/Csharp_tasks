using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    internal class Unit6
    {
        public Unit6(int w, int h)
        {
            mes = GetMaxAndMin;
            W = w;
            H = h;
            matrix = new int[h,w];
            Random rand = new Random();
            for (int i = 0; i < H; i++)
            {
                for(int j = 0; j < W;  j++)
                {
                    matrix[i,j] = rand.Next(55);
                    Console.Write("{0,-3}",matrix[i,j]);
                }
                Console.WriteLine("");
            }
        }
        public int W { get; set; }
        public int H { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int[,] matrix;
        public Message mes;

        public int GetMaxAndMin(int w, int h)
        {
            Max = matrix[0, 0];
            Min = matrix[0, 0];
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    if (matrix[i,j] > Max)
                    {
                        Max = matrix[i,j];
                    }
                    if (matrix[i,j] < Min)
                    {
                        Min= matrix[i,j];
                    }
                }
            }
            Console.WriteLine(Max - Min);
            return Max - Min;
        }

    }
    delegate int Message(int w, int h);
}
