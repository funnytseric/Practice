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
            Dictionary<int, int> dic = new Dictionary<int, int>();

            Sort(a, 0, a.Length-1);
            for (int i = 0; i < a.Length; i++)
                str += a[i].ToString() + " ";

            this.CountPrimeSetBits(10, 15);

            MessageBox.Show(str);
        }

        //swap function for quick sort
        private void Swap(int[] ary, int a, int b)
        {
            int temp = ary[a];
            ary[a] = ary[b];
            ary[b] = temp;
        }

        //quick sort implementation
        private void Sort(int[] ary, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = left;//chose the 1st element as pivot
            int pivotVal = ary[pivot];
            int swapIndex = left;

            Swap(ary, pivot, right);//swap pivot to right end

            //main loop, if the next number is less than pivot value,
            //swap it with the number on stored index, then increase the index by 1
            for(int i=left; i<right;i++)
            {
                if (ary[i] <= pivotVal)
                    Swap(ary, i, swapIndex++);
            }
            Swap(ary, swapIndex, right);//swap the pivot number back to the stored index

            //sort the two sub-sequences
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
                        perimeter += 4;//each islan cell contributes 4 boundaries

                        //if the previous cell is also an island cell, there are two boundaries are repeated
                        //so the sum of perimeter should be decreased by 2
                        if (h > 0 && grid[h - 1, w] == 1)
                            perimeter -= 2;
                        if (w > 0 && grid[h, w - 1] == 1)
                            perimeter -= 2;
                    }
                }

            return perimeter;
        }

        private int CountPrimeSetBits(int L, int R)
        {
            //the given numbers are guaranteed to be less than 10^6 (around 2^20)
            //so the sum of bits will less than 24, we can just list out prime numbers that less than 24
            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
            int result = 0;

            for (int i = L; i <= R; i++)
            {
                int j = i;
                int bitSum = 0;

                //convert integer bit by bit, and sum it up to get the bit count with "1"
                while (j > 0)
                {
                    bitSum += j % 2;
                    j >>= 1;
                }

                //check the prime number list to find whether the sum is a prime
                for (int k = 0; k < 8; k++)
                {
                    if (bitSum == primes[k])
                    {
                        result++;
                        break;
                    }
                }
            }
            return result;
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            else
            {
                //copy the node value from current node
                TreeNode node = new TreeNode(root.val);

                //recursively invert the two sub-nodes then assign them to the curren node
                node.left = root.right == null ? null : InvertTree(root.right);
                node.right = root.left == null ? null : InvertTree(root.left);

                //return the node with inversed sub-trees
                return node;
            }
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums.Length < 2)
                return nums[0];

            int result = 0, max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                    max++;
                else
                {
                    if (max > result)
                        result = max;
                    max = 0;
                }
            }
            return max > result ? max : result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int value)
        {
            this.val = value;
        }
    }
}
