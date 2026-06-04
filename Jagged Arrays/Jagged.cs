using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Arrays
{
    class Jagged
    {
        static void Main(string[] args)
        {
            //int[][] jaggedArray = new int[2][];
            //jaggedArray[0] = new int[3];
            //jaggedArray[1] = new int[2];
            ////initialize 1st array
            //jaggedArray[0][0] = 1;
            //jaggedArray[0][1] = 3;
            //jaggedArray[0][2] = 5;
            ////initialize 2nd array
            //jaggedArray[1][0] = 10;
            //jaggedArray[1][1] = 20;
            ////update array
            //jaggedArray[0][0] = 100;
            //jaggedArray[1][1] = 500;
            //for(int i=0;i<jaggedArray.Length;i++)
            //{
            //    Console.Write("Element" + i + ":");
            //    for(int j=0;j<jaggedArray[i].Length;j++)
            //    {
            //        Console.Write(jaggedArray[i][j]+ " ");
            //    }
            //    Console.WriteLine();

            //}
            //2d array
            //int[][,] jaggedArray2 = new int[3][,]
            // {

            //     new int[ , ] {{1,8},{6,7}},
            //     new int [ , ]{{0,3},{4,7},{6,7}},
            //     new int [,] {{50,60},{80,40},{70,80}}
            //  };

            ////Console.WriteLine(jaggedArray2[0][0,1]);
            ////Console.WriteLine(jaggedArray2[1][1,1]);
            ////Console.WriteLine(jaggedArray2[2][1,0]);
            //int[][,] array = new int[3][,]
            //    {

            //       new int [,] {{2,3},{2,4},{1,3}},
            //       new int [,] {{1,4},{4,3},{2,4}},
            //       new int [,] {{3,2},{2,2},{3,10}}
            //    };

            //for(int i=0;i<array.Length;i++)
            //{
            //    for (int j = 0; j < array[i].GetLength(0); j++)
            //    {
            //        for(int k=0;k<array[i].GetLength(1);k++)
            //        {
            //            Console.Write("array[" + i + "][" + j +"," + k + "])=>" +array[i][j,k]+ " ");
            //        }
            //    }
            //    Console.WriteLine();
            //}


            int[][] r = new int[][]
            {
            new int[] { 1, 2 },
            new int[] { 3, 4 },
            new int[] { 5, 6 }
        };

            //Console.WriteLine($"{r[0][0]}");
            //Console.WriteLine($"{r[0][1]}");
            //Console.WriteLine($"{ r[1][1]}");
            for(int i=0;i<r.Length;i++)
            {
                for(int j=0;j<r[i].Length;j++)
                {
                    Console.Write($"{r[i][j]} ");
                }
                Console.WriteLine();
            }



            Console.ReadKey();
        }
    }
}
