using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TronRacers
{
    public class Player
    {
        public Player(char name, int rowCurrent, int colCurrent, bool isLive = true)
        {
            Name = name;
            RowCurrent = rowCurrent;
            ColCurrent = colCurrent;
            IsLive = isLive;
        }

        public char Name { get; set; }
        public int RowCurrent { get; set; }
        public int ColCurrent { get; set; }
        public bool IsLive { get; set; }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            List<List<char>> field = new List<List<char>>();
            FieldField(sizeMatrix, field);
            Player first = FirndPlayer('f', field);
            Player second = FirndPlayer('s', field);
            while (first.IsLive && second.IsLive)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstCommand = command[0].ToLower();
                MovePlayer(firstCommand, first, field);
                if (!first.IsLive)
                {
                    break;
                }
                string secondCommand = command[1].ToLower();
                MovePlayer(secondCommand, second, field);
            }
                PrintMatrix(field);

        }

        private static void MovePlayer(string firstCommand, Player player, List<List<char>> field)
        {
            char singPlayer = player.Name;
            int newRow = player.RowCurrent;
            int newCol = player.ColCurrent;
            switch (firstCommand)
            {
                case "up":
                    newRow--;
                    if (newRow < 0)
                    {
                        newRow = field.Count - 1;
                    }
                    break;
                case "down":
                    newRow++;
                    if (newRow == field.Count)
                    {
                        newRow = 0;
                    }
                    break;
                case "right":
                    newCol++;
                    if (newCol == field[newRow].Count)
                    {
                        newCol = 0;
                    }
                    break;
                case "left":
                    newCol--;
                    if (newCol < 0)
                    {
                        newCol = field[newRow].Count - 1;
                    }
                    break;
                default:
                    break;
            }
            if (field[newRow][newCol] != '*')
            {
                field[newRow][newCol] = 'x';
                player.IsLive = false;
            }
            else
            {
                field[newRow][newCol] = singPlayer;
            }
            player.RowCurrent = newRow;
            player.ColCurrent = newCol;
        }

        private static Player FirndPlayer(char v, List<List<char>> field)
        {
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col] == v)
                    {
                        Player player = new Player(v, row, col);
                        return player;
                    }

                }
            }
            return null;
        }

        private static void PrintMatrix(List<List<char>> field)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FieldField(int sizeMatrix, List<List<char>> field)
        {
            for (int i = 0; i < sizeMatrix; i++)
            {
                List<char> newRow = Console.ReadLine().ToCharArray().ToList();
                field.Add(newRow);
            }
        }
    }
}
