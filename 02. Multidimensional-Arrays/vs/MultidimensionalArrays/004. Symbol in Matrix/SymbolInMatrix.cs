using System;
using System.Linq;

namespace _004._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberRowCol = int.Parse(Console.ReadLine());
            string[,] matrixSymbol = new string[numberRowCol, numberRowCol];
            for (int row = 0; row < matrixSymbol.GetLength(0); row++)
            {
                var colElements = Console.ReadLine().ToArray();
                for (int col = 0; col < matrixSymbol.GetLength(1); col++)
                {
                    matrixSymbol[row, col] = colElements[col].ToString();
                }
            }

            string searchingElements = Console.ReadLine();
            bool haveMach = false;
            for (int col = 0; col < matrixSymbol.GetLength(0); col++)
            {
                for (int row = 0; row < matrixSymbol.GetLength(1); row++)
                {
                    string currentElemetn = matrixSymbol[row, col];
                    if (currentElemetn == searchingElements)
                    {
                        Console.WriteLine($"({row}, {col})");
                        haveMach = true;
                        break;
                    }
                }
            }
            if (haveMach == false)
            {
                Console.WriteLine($"{searchingElements} does not occur in the matrix");
            }
        }
    }
}
