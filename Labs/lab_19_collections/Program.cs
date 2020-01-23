using System;

namespace lab_19_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] myArray = new int[10];
            //for (int x = 0; x < 10; x++)
            //{
            //    myArray[x] = x;
            //    Console.WriteLine(myArray[x]);
            //}

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");


            //2D array (10x10)
            int[,] myArray2 = new int[10, 10];

            int k = 0;

            for (int i = 0; i < myArray2.GetLength(0); i++)
            {
                for (int j = 0; j < myArray2.GetLength(1); j++)
                {
                    myArray2[i,j] = k;
                    k++;
                    Console.WriteLine(myArray2[i, j] + "\t");
                }
               
            }

            //3D array (10x10x10)

        }
    }
}
