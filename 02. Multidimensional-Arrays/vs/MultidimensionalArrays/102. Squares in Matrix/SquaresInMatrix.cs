namespace _102._Squares_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = sizeMatrix[0];
            int col = sizeMatrix[1];
            string[,] matrix = new string[row, col];
            FillMatrixWithChar(matrix);
            List<int[]> starIndexMiniMatrix = new List<int[]>();//row[first index] col[second index]
            FindTwoToTwoMatrixWihtEqualElement(matrix, starIndexMiniMatrix);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(starIndexMiniMatrix.Count);
        }

        private static void FindTwoToTwoMatrixWihtEqualElement(string[,] matrix, List<int[]> memory)
        {
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row,col]==matrix[row+1,col]&&
                        matrix[row+1,col+1]==matrix[row,col+1]&&
                        matrix[row, col]== matrix[row + 1, col + 1])
                    {
                        int[] startIndex = { row, col};
                        memory.Add(startIndex);
                    }

                }
            }
        }

        private static void FillMatrixWithChar(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] lineInput = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = lineInput[col];
                }
            }
        }
    }
}
