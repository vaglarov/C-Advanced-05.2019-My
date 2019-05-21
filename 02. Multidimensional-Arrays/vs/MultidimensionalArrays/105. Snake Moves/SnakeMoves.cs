namespace _105._Snake_Moves
{
    using System;
    using System.Linq;

    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            string snake = Console.ReadLine();
            FillMatrixWithSnake(matrix, snake);
            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FillMatrixWithSnake(char[,] matrix, string snake)
        {
            char[] snakeArr = snake.ToCharArray();
            int indexSnake = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (indexSnake == snakeArr.Count())
                    {
                        indexSnake = 0;
                    }
                    char symbol = snakeArr[indexSnake];
                    matrix[row, col] = symbol;
                    indexSnake++;
                }
            }
        }
    }
}
