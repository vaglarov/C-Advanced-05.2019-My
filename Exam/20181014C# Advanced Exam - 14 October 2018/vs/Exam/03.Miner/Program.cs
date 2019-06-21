using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Miner
{
    class Program
    {
        class Miner
        {
            public Miner(int row, int col, bool isAlive = true)
            {
                Row = row;
                Col = col;
                IsAlive = isAlive;
            }

            public bool IsAlive { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }
            public override string ToString()
            {
                return $"({Row}, {Col})"; 
            }
        }

        static void Main(string[] args)
        {
            int sizeFiled = int.Parse(Console.ReadLine());
            Queue<string> listCommands = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            List<List<char>> field = GreatFied(sizeFiled);
            Miner miner = FindMiner(field);
            int countCoal = CountCoal(field);
           // Console.WriteLine(countCoal);
            while (listCommands.Count > 0 && miner.IsAlive&&countCoal>0)
            {
                string command = listCommands.Dequeue();
                int newRow = miner.Row;
                int newCol = miner.Col;
                switch (command)
                {
                    case "up":
                        newRow--;
                        break;
                    case "down":
                        newRow++;
                        break;
                    case "right":
                        newCol++;
                        break;
                    case "left":
                        newCol--;
                        break;
                    default:
                        break;
                }
                MoveMiner(newRow, newCol, field, miner);
                countCoal = CountCoal(field);
            }
            if (countCoal==0&&miner.IsAlive)
            {
                Console.WriteLine($"You collected all coals! {miner}");
            }
            else if (countCoal != 0 && miner.IsAlive)
            {
                Console.WriteLine($"{countCoal} coals left. {miner}");
            }
            else
            {
                Console.WriteLine($"Game over! {miner}");
            }
          
        }

        private static void MoveMiner(int newRow, int newCol, List<List<char>> field,Miner miner)
        {
            field[miner.Row][miner.Col] = 'W';
          
            if (newRow>=0&&newCol>=0
                && newRow<field.Count
                && newCol<field[newRow].Count)
            {
                if (field[newRow][newCol] == 'e')
                {
                    miner.IsAlive = false;
                    miner.Row = newRow;
                    miner.Col = newCol;
                }
                else if (field[newRow][newCol] == 'c')
                {
                    field[newRow][newCol] = '*';
                }
                miner.Row = newRow;
                miner.Col = newCol;
            }
        }

        private static int CountCoal(List<List<char>> field)
        {
            int count = 0;
            foreach (var row in field)
            {
                foreach (var col in row)
                {
                    if (col=='c')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static Miner FindMiner(List<List<char>> field)
        {
            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    if (field[row][col] == 's')
                    {
                        Miner miner = new Miner(row, col);
                        return miner;

                    }
                }
            }
            return null;
        }

        private static void PrintField(List<List<char>> field)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var row in field)
            {   
                Console.WriteLine(string.Join("", row));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static List<List<char>> GreatFied(int sizeFiled)
        {
            List<List<char>> field = new List<List<char>>();
            for (int i = 0; i < sizeFiled; i++)
            {
                var rowField = Console.ReadLine().ToCharArray().ToList();
                rowField = rowField.Where(x=>x!=' ').ToList();
                field.Add(rowField);


            }
            return field;
        }
    }
}
