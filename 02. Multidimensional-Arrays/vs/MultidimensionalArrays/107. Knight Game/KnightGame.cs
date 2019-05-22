namespace _107._Knight_Game
{
    using System;
    class KnightGame
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrixTableField = new char[sizeMatrix, sizeMatrix];
            FillTableWithFigurs(matrixTableField);
            int countRemoveKnight = RemoveDisputeKnight(matrixTableField);
            Console.WriteLine(countRemoveKnight);
          //  PrintMatrix(matrixTableField);

        }

        private static int RemoveDisputeKnight(char[,] matrixTableField)
        {
            int count = 0;
            int countMax = 0;
            bool haveDisputeInFile = true;
            while (haveDisputeInFile)
            {
                haveDisputeInFile = false;
                int rowRemove = default(int);
                int colRemove = default(int);
                for (int row = 0; row < matrixTableField.GetLength(0); row++)
                {
                    for (int col = 0; col < matrixTableField.GetLength(1); col++)
                    {
                        if (matrixTableField[row, col] == 'K')
                        {
                            if (HaveDispute(row, col, matrixTableField))
                            {

                                int currentCount = CountDispute(row, col, matrixTableField);
                                if (countMax < currentCount)
                                {
                                    countMax = currentCount;
                                    rowRemove = row;
                                    colRemove = col;
                                }
                            }

                        }

                    }
                }
                if (countMax != 0)
                {
                    matrixTableField[rowRemove, colRemove] = 'W';
                    haveDisputeInFile = true;
                    countMax = 0;
                    count++;
                }
            }

            return count;
        }

        private static int CountDispute(int rowWithKnight, int colWithKnight, char[,] matrixTableField)
        {
            int count = 0;
            if (IsInside(rowWithKnight - 2, colWithKnight + 1, matrixTableField) &&
                matrixTableField[rowWithKnight - 2, colWithKnight + 1] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight - 2, colWithKnight - 1, matrixTableField) &&
                matrixTableField[rowWithKnight - 2, colWithKnight - 1] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight - 1, colWithKnight + 2, matrixTableField) &&
                matrixTableField[rowWithKnight - 1, colWithKnight + 2] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight - 1, colWithKnight - 2, matrixTableField) &&
             matrixTableField[rowWithKnight - 1, colWithKnight - 2] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight + 1, colWithKnight + 2, matrixTableField) &&
             matrixTableField[rowWithKnight + 1, colWithKnight + 2] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight + 1, colWithKnight - 2, matrixTableField) &&
             matrixTableField[rowWithKnight + 1, colWithKnight - 2] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight + 2, colWithKnight - 1, matrixTableField) &&
             matrixTableField[rowWithKnight + 2, colWithKnight - 1] == 'K')
            {
                count++;
            }
            if (IsInside(rowWithKnight + 2, colWithKnight + 1, matrixTableField) &&
             matrixTableField[rowWithKnight + 2, colWithKnight + 1] == 'K')
            {
                count++;
            }

            return count;
        }

        private static bool HaveDispute(int rowWithKnight, int colWithKnight, char[,] matrixTableField)
        {
            if (IsInside(rowWithKnight - 2, colWithKnight + 1, matrixTableField) &&
                matrixTableField[rowWithKnight - 2, colWithKnight + 1] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight - 2, colWithKnight - 1, matrixTableField) &&
                matrixTableField[rowWithKnight - 2, colWithKnight - 1] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight - 1, colWithKnight + 2, matrixTableField) &&
                matrixTableField[rowWithKnight - 1, colWithKnight + 2] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight - 1, colWithKnight - 2, matrixTableField) &&
             matrixTableField[rowWithKnight - 1, colWithKnight - 2] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight + 1, colWithKnight + 2, matrixTableField) &&
             matrixTableField[rowWithKnight + 1, colWithKnight + 2] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight + 1, colWithKnight - 2, matrixTableField) &&
             matrixTableField[rowWithKnight + 1, colWithKnight - 2] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight + 2, colWithKnight - 1, matrixTableField) &&
             matrixTableField[rowWithKnight + 2, colWithKnight - 1] == 'K')
            {
                return true;
            }
            else if (IsInside(rowWithKnight + 2, colWithKnight + 1, matrixTableField) &&
             matrixTableField[rowWithKnight + 2, colWithKnight + 1] == 'K')
            {
                return true;
            }

            return false;
        }

        private static bool IsInside(int row, int col, char[,] matrixTableField)
        {
            if (row >= 0 && row < matrixTableField.GetLength(0)
                && col >= 0 && col < matrixTableField.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(char[,] matrixTableField)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < matrixTableField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixTableField.GetLength(1); col++)
                {
                    Console.Write($" {matrixTableField[row, col]}");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void FillTableWithFigurs(char[,] matrixTableField)
        {
            for (int row = 0; row < matrixTableField.GetLength(0); row++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixTableField.GetLength(1); col++)
                {
                    matrixTableField[row, col] = inputLine[col];
                }
            }
        }
    }
}
