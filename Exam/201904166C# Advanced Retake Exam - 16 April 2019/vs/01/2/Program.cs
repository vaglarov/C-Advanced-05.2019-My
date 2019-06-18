namespace _2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Player
        {
            public Player(int row = 0, int col = 0, int health = 0,bool win=false)
            {
                Row = row;
                Col = col;
                Health = health;
                Win = win;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public int Health { get; set; }
            public bool Win { get; set; }



        }
        static void Main()
        {
            int energyPlayer = int.Parse(Console.ReadLine());
            int numberLineField = int.Parse(Console.ReadLine());
            List<List<char>> field = CreateField(numberLineField);
            Player player = FindPlayer(field, energyPlayer);
            while (true)
            {

                string[] lineImput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string moveDirection = lineImput[0].ToLower();
                AddEnemy(field, lineImput);
                int newRow = 0;
                int newCol = 0;
                switch (moveDirection)
                {
                    case "up":
                        newRow = -1;
                        break;
                    case "down ":
                        newRow = 1;
                        break;
                    case "left":
                        newCol = -1;
                        break;
                    case "right":
                        newCol = 1;
                        break;
                }
                if (IsInField(player, newRow, newCol, field))
                {
                    MovePlayer(player, newRow, newCol, field);
                }
                if (player.Health <= 0)
                {
                    field[player.Row][player.Col] = 'X';
                    Console.WriteLine($"Paris died at {player.Row};{player.Col}.");
                    PrintField(field);
                    break;

                }
                else if (player.Win == true)
                {
                    PrintField(field);
                    break;

                }
            }

        }

        /* private static void AddEnemyAndMovePlayer(List<List<char>> field, Player player)
         {
             string[] lineImput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
             string moveDirection = lineImput[0].ToLower();
             AddEnemy(field, lineImput);
             int newRow = 0;
             int newCol = 0;
             switch (moveDirection)
             {
                 case "up":
                     newRow = -1;
                     break;
                 case "down ":
                     newRow = 1;
                     break;
                 case "left":
                     newCol = -1;
                     break;
                 case "right":
                     newCol = 1;
                     break;
             }
             if (IsInField(player, newRow, newCol, field))
             {
                 MovePlayer(player, newRow, newCol, field);
             }
             if (player.Health <= 0)
             {
                 field[player.Row][player.Col] = 'X';
                 Console.WriteLine($"Paris died at {player.Row};{player.Col}.");

             }

         } */

        private static void MovePlayer(Player player, int newRow, int newCol, List<List<char>> field)
        {
            field[player.Row][player.Col] = '-';
            int newRowPlayer = player.Row + newRow;
            int newColPlayer = player.Col + newCol;
            player.Row = newRowPlayer;
            player.Col = newColPlayer;
            if (field[newRowPlayer][newColPlayer] == 'S')
            {
                player.Health -= 3;
                field[newRowPlayer][newColPlayer] = 'P';
            }
            else if (field[newRowPlayer][newColPlayer] == 'H')
            {
                player.Health -= 1;
                field[newRowPlayer][newColPlayer] = '-';
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {player.Health}");
                player.Win = true;
            }
            else
            {
                player.Health -= 1;
                field[newRowPlayer][newColPlayer] = 'P';
            }
        }

        private static bool IsInField(Player player, int newRow, int newCol, List<List<char>> field)
        {
            int newRowPlayer = player.Row + newRow;
            int newColPlayer = player.Col + newCol;

            if (newRowPlayer >= 0 && newRow < field.Count
                && newColPlayer >= 0 && newColPlayer < field[newRowPlayer].Count)
            {
                return true;
            }
            else
            {
                player.Health -= 1;
                return false;
            }
        }

        private static void AddEnemy(List<List<char>> field, string[] lineImput)
        {
            int enemyRow = int.Parse(lineImput[1]);
            int enemyCol = int.Parse(lineImput[2]);
            if (enemyRow >= 0 && enemyRow < field.Count
                && enemyCol >= 0 && enemyCol < field[enemyRow].Count)
            {
                field[enemyRow][enemyCol] = 'S';
            }
        }

        public static Player FindPlayer(List<List<char>> field, int energyPlayer)
        {
            for (int row = 0; row < field.Count(); row++)
            {
                for (int col = 0; col < field[row].Count(); col++)
                {
                    if (field[row][col] == 'P')
                    {
                        Player player = new Player(row, col, energyPlayer);
                        return player;
                    }
                }
            }
            return null;
        }

        private static void PrintField(List<List<char>> field)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var line in field)
            {
                Console.WriteLine(string.Join("", line));
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static List<List<char>> CreateField(int numberLineField)
        {
            List<List<char>> newfield = new List<List<char>>();
            for (int i = 0; i < numberLineField; i++)
            {
                var lineFild = Console.ReadLine()
                    .ToCharArray()
                    .ToList();
                newfield.Add(lineFild);
            }
            return newfield;
        }
    }

}
