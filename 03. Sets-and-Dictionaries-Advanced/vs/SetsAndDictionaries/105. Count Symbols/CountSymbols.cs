namespace _105._Count_Symbols
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dictCharInText = new Dictionary<char, int>();
            string lineInput = Console.ReadLine();
            FillDictionary(lineInput, dictCharInText);
            PrintDictionary(dictCharInText);
        }

        private static void PrintDictionary(Dictionary<char, int> dictCharInText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var kvp in dictCharInText.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FillDictionary(string lineInput, Dictionary<char, int> dictCharInText)
        {
            foreach (var charakter in lineInput)
            {
                if (!dictCharInText.ContainsKey(charakter))
                {
                    dictCharInText.Add(charakter, 1);
                }
                else
                {
                    dictCharInText[charakter]++;
                }
            }
        }
    }
}
