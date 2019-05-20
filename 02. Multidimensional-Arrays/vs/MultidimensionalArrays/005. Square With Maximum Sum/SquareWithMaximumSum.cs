
namespace _005._Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            var inputLineSizeMatrix = Console.ReadLine().
                 Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var sizeRow = int.Parse(inputLineSizeMatrix[0]);
            var sizeCol = int.Parse(inputLineSizeMatrix[1]);
            var matrix = new int[sizeRow, sizeCol];

            // Fill matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputColElement = Console.ReadLine().
                    Split(", ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputColElement[col];
                }
            }

            //Check for max Sum element in Matrinz 2 to 2
            var maxSumElementsInMatrixTwoToTwo = int.MinValue;
            var startIndexMaxMatrixRow = 0;
            var startIndexMaxMatrixCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var sumCurrentMatrix = matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col + 1];

                    if (sumCurrentMatrix > maxSumElementsInMatrixTwoToTwo)
                    {
                        maxSumElementsInMatrixTwoToTwo = sumCurrentMatrix;
                        startIndexMaxMatrixRow = row;
                        startIndexMaxMatrixCol = col;
                    }

                }

            }

            //Print max matrix
            Console.ForegroundColor = ConsoleColor.Red;
            for (int rowMax = startIndexMaxMatrixRow; rowMax <= startIndexMaxMatrixRow + 1; rowMax++)
            {
                for (int colMax = startIndexMaxMatrixCol; colMax <= startIndexMaxMatrixCol + 1; colMax++)
                {
                    Console.Write($"{matrix[rowMax, colMax]} ");

                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSumElementsInMatrixTwoToTwo);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
