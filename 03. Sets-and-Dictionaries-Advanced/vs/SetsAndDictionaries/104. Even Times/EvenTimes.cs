 using System;
using System.Collections.Generic;
using System.Linq;

namespace _104._Even_Times
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            Dictionary<int, int> dictDataNumbers = new Dictionary<int, int>();
            FillDictData(numberLineInput, dictDataNumbers);
            List<int> listEvenAppearence = FindOnlyEvenAppearnce(dictDataNumbers);
            PrintResult(listEvenAppearence);
        }

        private static void PrintResult(List<int> listEvenAppearence)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",listEvenAppearence));
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static List<int> FindOnlyEvenAppearnce(Dictionary<int, int> dictDataNumbers)
        {
            List<int> result = dictDataNumbers.Where(x => x.Value % 2 == 0).
                Select(x=>x.Key).
                ToList();
            return result;
        }

        private static void FillDictData(int numberLineInput, Dictionary<int, int> dictDataNumbers)
        {
            for (int index = 0; index < numberLineInput; index++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!dictDataNumbers.ContainsKey(currentNumber))
                {
                    dictDataNumbers.Add(currentNumber, 1);
                }
                else
                {
                    dictDataNumbers[currentNumber]++;
                }
            }
        }
    }
}
