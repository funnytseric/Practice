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
        public Form1()
        {
            InitializeComponent();

            Stack<>
            }
            int debug = 0;
        }

        private bool test()
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            int num;
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (row <= 1 || col <= 1)
                return false;
            else
            {
                for (int i = 0; i < row - 1; i++)
                    for (int j = 0; j < col - 1; j++)
                    {
                        num = matrix[i, j];
                        int k = 0;
                        while (k + i < row && k+j < col)
                        {
                            if (matrix[i + k, j + k] != num)
                                return false;
                            else
                                k++;
                        }
                    }
            }
            return true;
        }
    }
}
