namespace _101._Diagonal_Difference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int sizeMatrinx = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeMatrinx, sizeMatrinx];
            FillMatrixWithValue(matrix);
            int upLeftToDownRightDiagonal = GetSumElemetnUpLeftDownRight(matrix);
            int upRightToDownLeftDiagonal = GetSumElemetnUpRightDownLeft(matrix);
            int diagonalDifference = Math.Abs(upLeftToDownRightDiagonal - upRightToDownLeftDiagonal);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(diagonalDifference);
        }

        private static int GetSumElemetnUpRightDownLeft(int[,] matrix)
        {
            int sum = default(int);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row+col)==matrix.GetLength(0)-1)
                    {
                        sum += matrix[row, col];
                    }
                }

            }
            return sum;
        }

        private static int GetSumElemetnUpLeftDownRight(int[,] matrix)
        {
            int sum = default(int);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row==col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            return sum;
        }

        private static void FillMatrixWithValue(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arrLineMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arrLineMatrix[col];
                }
            }
        }
    }
}
 