
namespace _106._Bomb_the_Basement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BombTheBasement
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            List<List<int>> jaggedMatrix = new List<List<int>>();
            GreatAndFillMatrix(jaggedMatrix, sizeMatrix);
            int[] bombArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            //only for me
        
            if (CheckIsTargetIsInMatrix(bombArr, jaggedMatrix))
            {
                ShotMatrix(jaggedMatrix, bombArr);
                ArrangeMatrix(jaggedMatrix);
                PrintMatrix(jaggedMatrix);
            }
        }

        private static void ArrangeMatrix(List<List<int>> jaggedMatrix)
        {

            for (int col = 0; col < jaggedMatrix[0].Count; col++)
            {
                int countShot = 0;
                for (int row = 0; row < jaggedMatrix.Count; row++)
                {
                    if (jaggedMatrix[row][col]==1)
                    {
                        countShot++;
                        jaggedMatrix[row][col] = 0;
                    }
                }
                for (int row = 0; row < countShot; row++)
                {
                    jaggedMatrix[row][col] = 1;
                }
            }
        }

        private static void ShotMatrix(List<List<int>> jaggedMatrix, int[] bombArr)
        {
            for (int row = 0; row < jaggedMatrix.Count; row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Count; col++)
                {
                    if (isInBombRange(row, col, bombArr))
                    {
                        jaggedMatrix[row][col] = 1;
                    }
                }
            }

        }

        private static bool isInBombRange(int row, int col, int[] bombArr)
        {
            int rowTarget = bombArr[0];
            int colTarget = bombArr[1];
            int rangeBomn = bombArr[2];
            if (Math.Pow((rowTarget - row), 2) + Math.Pow((colTarget - col), 2) <= Math.Pow(rangeBomn, 2))
            {
                return true;
            }
            return false;
        }

        private static bool CheckIsTargetIsInMatrix(int[] bombArr, List<List<int>> jaggedMatrix)
        {
            int targerRow = bombArr[0];
            int targetCol = bombArr[1];
            if ((targerRow >= 0 && targerRow < jaggedMatrix.Count())
                && (targetCol >= 0 && targetCol < jaggedMatrix[0].Count()))
            {
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Miss target!!!");
            Console.WriteLine("Try again bro!!");
            Console.ForegroundColor = ConsoleColor.White;
            return false;

        }

        private static void PrintMatrix(List<List<int>> jaggedMatrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int row = 0; row < jaggedMatrix.Count(); row++)
            {
                Console.WriteLine(string.Join("", jaggedMatrix[row]));
            }

            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void GreatAndFillMatrix(List<List<int>> jaggedMatrix, int[] sizeMatrix)
        {
            int sizeRow = sizeMatrix[0];
            int sizeCol = sizeMatrix[1];

            for (int row = 0; row < sizeRow; row++)
            {
                jaggedMatrix.Add(new List<int>());
                for (int col = 0; col < sizeCol; col++)
                {
                    jaggedMatrix[row].Add(0);
                }
            }
        }
    }
}
