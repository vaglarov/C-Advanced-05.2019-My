namespace _109._Miner
{
    using System;
    class Miner
    {
        public static int totalCoals = 0;
        public static int[] snakeCoordinate=new int[2];


        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            string[] commandArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrixField = new char[sizeField, sizeField];
            FillMatrixField(matrixField);
           // PrintMatrix(matrixField);
            FindTheSnake(matrixField);
            bool endGame = false;
            for (int indexRound = 0; indexRound < commandArg.Length; indexRound++)
            {
                string command = commandArg[indexRound];
                switch (command)
                {
                    case "up":
                        if (IsInside(-1,0, matrixField))
                        {
                            snakeCoordinate[0] -= 1;
                            switch (matrixField[snakeCoordinate[0],snakeCoordinate[1]])
                            {
                                case '*':
                                    IsAStar(matrixField);
                                    break;
                                case 'c':
                                    IsACoal(matrixField);
                                    if (HaveNoMoreCoal(matrixField))
                                    {
                                        Console.WriteLine($"You collected all coals! ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
                                        endGame = true;
                                    }
                                    break;
                                case 'e':
                                    if (EndGame())
                                    {
                                        endGame = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "down":
                        if (IsInside(+1, 0, matrixField))
                        {
                            snakeCoordinate[0] += 1;
                            switch (matrixField[snakeCoordinate[0], snakeCoordinate[1]])
                            {
                                case '*':
                                    IsAStar(matrixField);
                                    break;
                                case 'c':
                                    IsACoal(matrixField);
                                    if (HaveNoMoreCoal(matrixField))
                                    {
                                        Console.WriteLine($"You collected all coals! ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
                                        endGame = true;
                                    }
                                    break;
                                case 'e':
                                    if (EndGame())
                                    {
                                        endGame = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "right":
                        if (IsInside(0, +1, matrixField))
                        {
                            snakeCoordinate[1] += 1;
                            switch (matrixField[snakeCoordinate[0], snakeCoordinate[1]])
                            {
                                case '*':
                                    IsAStar(matrixField);
                                    break;
                                case 'c':
                                    IsACoal(matrixField);
                                    if (HaveNoMoreCoal(matrixField))
                                    {
                                        Console.WriteLine($"You collected all coals! ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
                                        endGame = true;
                                    }
                                    break;
                                case 'e':
                                    if (EndGame())
                                    {
                                        endGame = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    case "left":
                        if (IsInside(0, -1, matrixField))
                        {
                            snakeCoordinate[1] -= 1;
                            switch (matrixField[snakeCoordinate[0], snakeCoordinate[1]])
                            {
                                case '*':
                                    IsAStar(matrixField);
                                    break;
                                case 'c':
                                    IsACoal(matrixField);
                                    if (HaveNoMoreCoal(matrixField))
                                    {
                                        Console.WriteLine($"You collected all coals! ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
                                        endGame = true;
                                    }
                                    break;
                                case 'e':
                                    if (EndGame())
                                    {
                                        endGame = true;
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong command bro!!!");
                        break;
                }
                if (endGame)
                {
                    break;
                }
            }
            if (!endGame)
            {
                Console.WriteLine($"3 coals left. ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
            }
        }

        private static bool HaveNoMoreCoal(char[,] matrixField)
        {
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    if (matrixField[row,col]=='c')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void IsACoal(char[,] matrixField)
        {
            totalCoals++;
            matrixField[snakeCoordinate[0], snakeCoordinate[1]] = 's';
           
        }

        private static void IsAStar(char[,]matrixField)
        {
            matrixField[snakeCoordinate[0], snakeCoordinate[1]] = 's';
           
        }

        private static bool EndGame()
        {
            Console.WriteLine($"Game over! ({snakeCoordinate[0]}, {snakeCoordinate[1]})");
            return true;
        }

        private static bool IsInside(int moveRow, int moveCol, char[,] matrixField)
        {
            int newSnakeRow = snakeCoordinate[0] + moveRow;
            int newSnakeCol = snakeCoordinate[1] + moveCol;
            if (newSnakeRow>=0&&newSnakeRow<matrixField.GetLength(0)
                && newSnakeCol>=0&&newSnakeCol<matrixField.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(char[,] matrixField)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    Console.Write(matrixField[row, col]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static int[] FindTheSnake(char[,] matrixField)
        {
           for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    if (matrixField[row, col] == 's')
                    {
                       
                        snakeCoordinate[0] = row;
                        snakeCoordinate[1] = col;
                        return snakeCoordinate;
                    }
                }
            }
            Console.WriteLine("Don't have snake in field!!!");
            return snakeCoordinate;
        }

        private static void FillMatrixField(char[,] matrixField)
        {
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                string[] colLineInput = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    matrixField[row, col] = char.Parse(colLineInput[col]);
                }
            }
        }
    }
}
