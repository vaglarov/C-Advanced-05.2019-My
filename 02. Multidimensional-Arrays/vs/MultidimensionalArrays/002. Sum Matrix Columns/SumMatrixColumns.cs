namespace _002._Sum_Matrix_Columns
{
    using System;
    using System.Linq;

    class SumMatrixColumns
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
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int colMatric = 0; colMatric < matrix.GetLength(1); colMatric++)
                {
                    matrix[rowMatrix, colMatric] = inputLineMatrix[colMatric];
                }
            }

            for (int colMatric = 0; colMatric < matrix.GetLength(1); colMatric++)
            {
                var resultSumCol = default(int);
                for (int rowMatrix = 0; rowMatrix < matrix.GetLength(0); rowMatrix++)
                {
                    resultSumCol += matrix[rowMatrix, colMatric];
                }
                Console.WriteLine(resultSumCol);
            }

        }
    }
}
