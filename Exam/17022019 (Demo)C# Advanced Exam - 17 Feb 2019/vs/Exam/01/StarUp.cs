using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            List<string> header = new List<string>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries));
            //RealTable
            List<List<string>> table = new List<List<string>>();
            AddValueInTable(table, numberLineInput);
            string[] command = Console.ReadLine().Split();
            switch (command[0])
            {
                case "hide":
                    HideColon(table, command, header);
                    break;
                case "sort":
                    table=SortTable(table, command, header);
                    break;
                case "filter":
                    table =FilterTable(table, command, header);
                    break;
                default:
                    break;
            }
            PrintTable(header, table);

        }

        private static List<List<string>> FilterTable(List<List<string>> table, string[] command, List<string> header)
        {
            string colName = command[1];
            int idexCol = header.IndexOf(colName);
            string value= command[2];
            table = table.Where(x => x.ElementAt(idexCol)== value).ToList();
            return table;
        }

        private static void PrintTable(List<string> header, List<List<string>> table)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" | ", header));
            foreach (var row in table)
            {
                Console.WriteLine(string.Join(" | ", row));
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static List<List<string>> SortTable(List<List<string>> table, string[] command, List<string> header)
        {
            string colName = command[1];
            int idexCol = header.IndexOf(colName);
            table= table.OrderBy(x =>x.ElementAt(idexCol)).ToList();
            return table;
        }

        private static void HideColon(List<List<string>> table, string[] command, List<string> header)
        {
            string colName = command[1];
            int deleteIndex= header.IndexOf(colName);
            header.RemoveAt(deleteIndex);
            foreach (var row in table)
            {
                row.RemoveAt(deleteIndex);
            }
        }

        private static void AddValueInTable(List<List<string>> table,int lineNumber)
        {
            for (int i = 0; i < lineNumber-1; i++)
            {
                List<string> newLine = new List<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
                table.Add(newLine);
            }
        }
    }
}
