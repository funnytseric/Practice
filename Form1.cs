using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();

            int[] a = new int[10];
            string str = "numbers before sorted: ";
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(100);
                str += a[i].ToString() + " ";
            }
            str += "\n";

            Sort(a, 0, a.Length-1);
            for (int i = 0; i < a.Length; i++)
                str += a[i].ToString() + " ";

            MessageBox.Show(str);
        }

        private void Swap(int[] ary, int a, int b)
        {
            int temp = ary[a];
            ary[a] = ary[b];
            ary[b] = temp;
        }

        private void Sort(int[] ary, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = left;
            int pivotVal = ary[pivot];
            int swapIndex = left;

            Swap(ary, pivot, right);
            for(int i=left; i<right;i++)
            {
                if (ary[i] <= pivotVal)
                    Swap(ary, i, swapIndex++);
            }
            Swap(ary, swapIndex, right);

            Sort(ary, left, swapIndex - 1);
            Sort(ary, swapIndex + 1, right);
        }

        public int IslandPerimeter(int[,] grid)
        {
            int perimeter = 0;
            int height = grid.GetLength(0);
            int width = grid.GetLength(1);

            //original code, not os effecient
            /*for(int h=0; h<height; h++)
                for(int w=0; w<width; w++)
                {
                    if(grid[h,w] == 1)
                    {
                        perimete += 4;
                        if(h-1 >= 0)
                            perimete -= grid[h-1,w];
                        if(h+1 < height)
                            perimete -= grid[h+1,w];
                        if(w-1 >= 0)
                            perimete -= grid[h,w-1];
                        if(w+1 < width)
                            perimete -= grid[h,w+1];
                    }
                }*/

            for (int h = 0; h < height; h++)
                for (int w = 0; w < width; w++)
                {
                    if (grid[h, w] == 1)
                    {
                        perimeter += 4;

                        if (h > 0 && grid[h - 1, w] == 1)
                            perimeter -= 2;
                        if (w > 0 && grid[h, w - 1] == 1)
                            perimeter -= 2;
                    }
                }

            return perimeter;
        }
    }
}
