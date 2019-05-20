
namespace _001._Sum_Matrix_Elements
{
using System;
using System.Linq;
    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rol = int.Parse(inputLine[0]);
            int col = int.Parse(inputLine[1]);
            int[,] matrix = new int[rol, col];
            //Fill Matrix
            for (int rowMatrix = 0; rowMatrix < matrix.GetLength(0); rowMatrix++)
            {
                var inputLineMatrix = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int colMatric = 0; colMatric < matrix.GetLength(1); colMatric++)
                {
                    matrix[rowMatrix, colMatric] = inputLineMatrix[colMatric];
                }
            }

            Console.ForegroundColor=ConsoleColor.Red;
            int sumAll = default(int);
            foreach (var item in matrix)
            {
                sumAll += item;
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
                Console.WriteLine(sumAll);
               
        }
    }
}
