namespace _103._Maximal_Sum
{
    using System;
    using System.Linq;

    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrixInt = new int[sizeMatrix[0], sizeMatrix[1]];
            FillMatrixWithValue(matrixInt);
            int[] startIndexMatrixMaxSum = new int[2];
            startIndexMatrixMaxSum = FindMaxSumMatrix3x3(matrixInt);
            Console.ForegroundColor = ConsoleColor.Red;
            PrintMaxSumAndMatrix(startIndexMatrixMaxSum, matrixInt);
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void PrintMaxSumAndMatrix(int[] startIndexMatrixMaxSum, int[,] matrixInt)
        {
            int maxSum = 0;
            for (int row = startIndexMatrixMaxSum[0]; row <= startIndexMatrixMaxSum[0] + 2; row++)
            {
                for (int col = startIndexMatrixMaxSum[1]; col <= startIndexMatrixMaxSum[1] + 2; col++)
                {
                    maxSum += matrixInt[row, col];
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startIndexMatrixMaxSum[0]; row <= startIndexMatrixMaxSum[0] + 2; row++)
            {
                for (int col = startIndexMatrixMaxSum[1]; col <= startIndexMatrixMaxSum[1] + 2; col++)
                {
                    if (col == startIndexMatrixMaxSum[1] + 2)
                    {
                        Console.Write($"{matrixInt[row, col]}");
                    }
                    else
                    {
                        Console.Write($"{matrixInt[row, col]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static int[] FindMaxSumMatrix3x3(int[,] matrixInt)
        {
            int maxSum = int.MinValue;
            int[] startIndexMatrixMaxSum = new int[2];
            for (int row = 0; row < matrixInt.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrixInt.GetLength(1) - 2; col++)
                {
                    int currentSum = default(int);
                    for (int currentRow = row; currentRow <= row + 2; currentRow++)
                    {
                        for (int currentCol = col; currentCol <= col + 2; currentCol++)
                        {
                            currentSum += matrixInt[currentRow, currentCol];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startIndexMatrixMaxSum[0] = row;
                        startIndexMatrixMaxSum[1] = col;
                    }
                }
            }

            return startIndexMatrixMaxSum;
        }

        private static void FillMatrixWithValue(int[,] matrixInt)
        {
            for (int row = 0; row < matrixInt.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                for (int col = 0; col < matrixInt.GetLength(1); col++)
                {
                    matrixInt[row, col] = inputLine[col];
                }
            }
        }
    }
}
