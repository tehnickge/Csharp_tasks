using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_units
{
    internal class Unit2
    {
        private char[,] field;
        private int w, h;
        private int viewRadius, countBomb;
        public Unit2(int w, int h, int countBomb) 
        {
            this.field = new char[h, w];
            this.w = w; this.h = h; this.countBomb = countBomb; this.viewRadius = 1;
            FillField();
            PrintField();
            foreach (int i in PrintCountAreaBombs())
            {
                Console.Write(i + " ");
            }
        }

        public List<int> PrintCountAreaBombs()
        {
            List<int> res = new List<int>();
            for (int i = 0; i < this.h; i++)
            {
                for (int j = 0; j < this.w; j++)
                {
                   int counter = 0;
                   if(j - this.viewRadius >= 0) { if (this.field[i, j - this.viewRadius] == '@' ) counter++; }
                   if(i - this.viewRadius >= 0) { if (this.field[i - this.viewRadius, j] == '@') counter++; }
                   if(j + this.viewRadius <= this.w - 1) { if (this.field[i, j + this.viewRadius] == '@') counter++; }
                   if(i + this.viewRadius <= this.h - 1) { if (this.field[i + this.viewRadius, j] == '@') counter++; }
                   if (j - this.viewRadius >= 0 && i - this.viewRadius >= 0) { if (this.field[i - this.viewRadius, j - this.viewRadius] == '@') counter++; }
                   if (j + this.viewRadius <= this.w - 1 && i - this.viewRadius >= 0) { if (this.field[i - this.viewRadius, j + this.viewRadius] == '@') counter++; }
                   if (j - this.viewRadius >= 0 && i + this.viewRadius <= this.h - 1) { if (this.field[i + this.viewRadius, j - this.viewRadius] == '@') counter++; }
                   if (j + this.viewRadius <= this.w - 1 && i + this.viewRadius <= this.h - 1) { if (this.field[i + this.viewRadius, j + this.viewRadius] == '@') counter++; }


                   res.Add(counter);


                }
                Console.WriteLine("");

            }
            return res;
        }

        public void PrintField()
        {
            for (int i = 0; i < this.h; i++)
            {
                for (int j = 0; j < this.w; j++)
                {
                    Console.Write("{0,-3}", this.field[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
        
        public void FillField()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.h ; i++) 
            {
                for (int j = 0; j < this.w; j++)
                {
                    this.field[i,j] = '#';
                    Console.Write("{0,-3}",this.field[i, j] + " ");
                }
                Console.WriteLine("");
            }

            for(int i = 0;i < this.countBomb; i++)
            {
                int x,y;
                x = rnd.Next(0, this.w);
                y = rnd.Next(0, this.h);
                this.field[y, x] = '@';
            }
            Console.WriteLine("--------------------------");
        }


    }
}
