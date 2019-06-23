using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    public class SpaceShip
    {
        public SpaceShip(int row, int col, int point, int needMoney = 0, bool isIlive = true)
        {
            Row = row;
            Col = col;
            Point = point;
            NeedMoney = needMoney;
            IsIlive = isIlive;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Point { get; set; }
        public int NeedMoney { get; set; }
        public bool IsIlive { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            List<List<string>> field = GreateField(sizeMatrix);
            SpaceShip player = FindPlayer(field);
            string command = Console.ReadLine();
            while (true)
            {
                int newRow = player.Row;
                int newCol = player.Col;
                switch (command)
                {
                    case "up":
                        newRow -= 1;
                        break;
                    case "down":
                        newRow += 1;
                        break;
                    case "left":
                        newCol -= 1;
                        break;
                    case "right":
                        newCol += 1;
                        break;
                    default:
                        break;
                }
                MovePlayer(field, player, newRow, newCol);
                if (!player.IsIlive || player.NeedMoney >= 50)
                {
                    break;
                }

                command = Console.ReadLine();
            }
            if (!player.IsIlive)
            {
                Console.WriteLine($"Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {player.NeedMoney}");

            }
            if (player.NeedMoney >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {player.NeedMoney}");
            }
            PrintMatrix(field);
        }


        private static void MovePlayer(List<List<string>> field, SpaceShip player, int newRow, int newCol)
        {
            if (newRow == field.Count || newRow < 0 || field[0].Count == newCol || newCol < 0)
            {
                field[player.Row][player.Col] = "-";
               // player.NeedMoney = 0;
                MarkHoleZiro(field);
                player.IsIlive = false;
            }
            else
            {
                if (field[newRow][newCol] == "O"|| field[newRow][newCol] == "o"|| field[newRow][newCol] == "0")
                {
                    field[newRow][newCol] = "-";
                    field[player.Row][player.Col] = "-";
                    FindAnotherBlackHole(field, player);
                    
                }
                else if (field[newRow][newCol] != "-")
                {
                    int money = int.Parse(field[newRow][newCol].ToString());
                    player.NeedMoney += money;
                    field[player.Row][player.Col] = "-";
                    field[newRow][newCol] = "S";
                    player.Row = newRow;
                    player.Col = newCol;
                }
                else
                {
                    field[player.Row][player.Col] = "-";
                    field[newRow][newCol] = "S";
                    player.Row = newRow;
                    player.Col = newCol;
                }

            }
        }

        private static bool HaveAnotheHole(List<List<string>> field)
        {
            bool have = false;
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col]=="O")
                    {
                        have = true;
                        break;
                    }
                }
            }
            return have;
        }

        private static void FindAnotherBlackHole(List<List<string>> field, SpaceShip player)
        {
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col] == "O")
                    {
                        field[row][col] = "S";
                        player.Row = row;
                        player.Col = col;
                        break;
                    }
                }
            }
        }

        private static void MarkHoleZiro(List<List<string>> field)
        {
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col] == "O")
                    {
                        field[row][col] = "-";
                    }
                }
            }
        }

        private static SpaceShip FindPlayer(List<List<string>> field)
        {
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col] == "S")
                    {
                        SpaceShip player = new SpaceShip(row, col, 0);
                        return player;
                    }
                }

            }

            return null;

        }

        private static void PrintMatrix(List<List<string>> field)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static List<List<string>> GreateField(int sizeMatrix)
        {
            List<List<string>> field = new List<List<string>>();

            for (int row = 0; row < sizeMatrix; row++)
            {
                string lineInput = Console.ReadLine();
                char[] test = lineInput.ToCharArray();
                Queue<char> line = new Queue<char>(test);

                List<string> lineField = new List<string>();
                while (line.Count!=0)
                {
                    var elemt = line.Dequeue();

                    if (elemt=='1')
                    {
                        elemt = line.Dequeue();
                        string element = "10";
                        lineField.Add(element);

                    }
                    else
                    {
                        var element = elemt.ToString();
                        lineField.Add(element);

                    }

                }
                field.Add(lineField);


            }
            return field;
        }
    }
}
