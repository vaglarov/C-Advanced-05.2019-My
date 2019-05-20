
namespace _003._Primary_Diagonal
{
    using System;
    using System.Linq;

    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int rol = int.Parse(Console.ReadLine());
            int col = rol;
            int[,] matrix = new int[rol, col];

            //Fill Matrix

            for (int rowMatrix = 0; rowMatrix < matrix.GetLength(0); rowMatrix++)
            {
                var inputLineMatrix = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int colMatric = 0; colMatric < matrix.GetLength(1); colMatric++)
                {
                    matrix[rowMatrix, colMatric] = inputLineMatrix[colMatric];
                }
            }

            var resultSumDiagonals = default(int);
            for (int colMatric = 0; colMatric < matrix.GetLength(1); colMatric++)
            {
                    resultSumDiagonals += matrix[colMatric, colMatric];
            }
                Console.WriteLine(resultSumDiagonals);
        }
    }
}
