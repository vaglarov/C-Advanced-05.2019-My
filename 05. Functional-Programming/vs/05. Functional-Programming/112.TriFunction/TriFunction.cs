﻿using System;
using System.Linq;

namespace _112.TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().
                Split();

            Func<string, int, bool> isLarger = (name, charsLenght)
                     => name.Sum(x => x) >= charsLenght;
            Func<string[], Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, lenght));
            string resultName = nameFilter(names, isLarger);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(resultName);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
