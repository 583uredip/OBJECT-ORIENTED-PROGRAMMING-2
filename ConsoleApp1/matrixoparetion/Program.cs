using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrixoparetion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Number Of Rows:");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter Number Of Columns");
            int colums = int.Parse(Console.ReadLine());

            int[,] A = new int[rows, colums];
            int[,] B = new int[rows, colums];

            Console.WriteLine("\nEnter Element Of Matrix A ");
            inPutMatrix(A, rows, colums);
            Console.WriteLine("\nEnter Element Of Matrix B");
            inPutMatrix(B, rows, colums);
            Console.WriteLine("Matrix Addition Answer");
            printMatrix(Add(A, B, rows, colums));
            Console.WriteLine("Matrix Subtract Answer");
            printMatrix(sub(A, B, rows, colums));
            Console.WriteLine("Matrix Multiply Answer");
            printMatrix(mul(A, B, rows, colums));
            Console.WriteLine("Matrix Divison Answer");
            printMatrix(div(A, B, rows, colums));
            Console.ReadKey();
        }

        static void inPutMatrix(int[,] M,int r,int c)
        {
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    Console.Write($"M[{i},{j}] =");
                    M[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static int[,] Add(int[,] A, int[,] B, int r, int c)
        {
            int[,] R = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for(int j=0;j<c;j++)
                {
                    R[i, j] = A[i,j] + B[i,j];
                }
            }
            return R;
        }

        static int [,] sub(int [,] A,int [,] B,int r,int c)
        {
            int[,] R = new int[r, c];
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    R[i, j] = A[i, j] - B[i, j];
                }
            }
            return R;
        }
        
        static int [,] mul(int [,] A,int [,] B,int c,int r)
        {
            int[,] R = new int[r, c];
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<0;j++)
                {
                    R[i, j] = A[i, j] * B[i, j];
                }
            }
            return R;
        }

        static int[,] div(int[,] A, int[,] B, int r, int c)
        {
            int[,] R = new int[r, c];
            for (int i = 0; i < r; i++)
            {
                for(int j=0;j<c;j++)
                {
                    R[i, j] = B[i, j] != 0 ? A[i, j] / B[i, j] : 0;
                }
            }
            return R;
        }

        static void printMatrix(int [,] M)
        {
            int r = M.GetLength(0);
            int c = M.GetLength(1);
            for(int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        
    }
}
