namespace _104._Matrix_Shuffling
{
    using System;
    using System.Linq;

    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[sizeMatrix[0], sizeMatrix[1]];
            FillMatrix(matrix);
            string command = string.Empty;
            while ((command=Console.ReadLine())!= "END")
            {
                string[] commandSplit = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool isCorrectInput=CheckIsCorrectInput(commandSplit, matrix);
                if (isCorrectInput)
                {
                    SwapElement(commandSplit, matrix);
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintMatrix(matrix);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col==matrix.GetLength(1)-1)
                    {
                        Console.Write($"{matrix[row,col]}");
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void SwapElement(string[] commandSplit, string[,] matrix)
        {
            int firstRowIndex =int.Parse( commandSplit[1]);
            int firstColIndex = int.Parse(commandSplit[2]);
            int secondRowIndex = int.Parse(commandSplit[3]);
            int secondColIndex = int.Parse(commandSplit[4]);
            string elementFirst = matrix[firstRowIndex, firstColIndex];
            string elementSecond = matrix[secondRowIndex, secondColIndex];
            matrix[secondRowIndex, secondColIndex] = elementFirst;
            matrix[firstRowIndex, firstColIndex] = elementSecond;
        }

        private static bool CheckIsCorrectInput(string[]  command,string[,]matrix)
        {
            if (command.Length!=5)
            {
                Console.WriteLine("Invalid input!");
                return false;
            }
            else
            {
                if (command[0]!= "swap")
                {
                    Console.WriteLine("Invalid input!");
                    return false;
                }
                else if(!CheckCoordinats(matrix,command))
                {
                    Console.WriteLine("Invalid input!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private static bool CheckCoordinats(string[,] matrix, string[] command)
        {
            int firstRowIndex = int.Parse(command[1]);
            int firstColIndex= int.Parse(command[2]);
            int secondRowIndex = int.Parse(command[3]);
            int secondColIndex = int.Parse(command[4]);
            if (firstRowIndex<0||firstRowIndex>matrix.GetLength(0)-1)
            {
                return false;
            }
            if (firstColIndex < 0 || firstColIndex > matrix.GetLength(1) - 1)
            {
                return false;
            }
            if (secondRowIndex < 0 || secondRowIndex > matrix.GetLength(0) - 1)
            {
                return false;
            }
            if (secondColIndex < 0 || secondColIndex > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var lineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = lineInput[col];
                }
            }
        }
    }
}
