namespace _108._Bombs
{
    using System;
    using System.Linq;

    class Bombs
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            FillMatrix(matrix);
            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ExplodeBomb(bombs, matrix);
            SumAlive(matrix);
            Print(matrix);
        }

        private static void SumAlive(int[,] matrix)
        {
            int count = 0;
            int sum = 0;
            foreach (var item in matrix)
            {
                if (item>0)
                {
                    count++;
                    sum += item;
                }
            }
            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
        }

        private static void ExplodeBomb(string[] bombs, int[,] matrix)
        {
            for (int index = 0; index < bombs.Length; index++)
            {
                int[] bombCoordinats = bombs[index].Split(',').Select(int.Parse).ToArray();
                int valueBomb = matrix[bombCoordinats[0], bombCoordinats[1]];
                if (valueBomb > 0)
                {

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (IsInBombRange(bombCoordinats, matrix, row, col) && matrix[row, col] > 0)
                            {
                                matrix[row, col] -= valueBomb;
                            }
                        }
                    }
                }
             }
        }

        private static bool IsInBombRange(int[] bombCoordinats, int[,] matrix, int row, int col)
        {
            int rowBomb = bombCoordinats[0];
            int colBomb = bombCoordinats[1];
            int valueBomb = matrix[rowBomb, colBomb];
            if (row <= rowBomb + 1 && row >= rowBomb - 1
                && col <= colBomb + 1 && col >= colBomb - 1)
            {
                return true;
            }
            return false;
        }

        private static void Print(int[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputLinte = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLinte[col];
                }
            }
        }
    }
}
