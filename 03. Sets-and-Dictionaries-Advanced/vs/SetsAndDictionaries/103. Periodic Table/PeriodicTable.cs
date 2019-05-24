namespace _103._Periodic_Table
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            HashSet<string> hashSetChemicalElements = new HashSet<string>();
            FillDataInput(numberLineInput, hashSetChemicalElements);
            PrintOrder(hashSetChemicalElements);
        }

        private static void PrintOrder(HashSet<string> hashSetChemicalElements)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",hashSetChemicalElements.OrderBy(x=>x)));
            Console.ForegroundColor = ConsoleColor.White;


        }

        private static void FillDataInput(int numberLineInput, HashSet<string> hashSetChemicalElements)
        {
            for (int indexLineInput = 0; indexLineInput < numberLineInput; indexLineInput++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var element in elements)
                {
                    if (!hashSetChemicalElements.Contains(element))
                    {
                        hashSetChemicalElements.Add(element);
                    }
                }
            }
        }
    }
}
