namespace _104._Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] inputInterval = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries).
                 Select(int.Parse).
                 OrderBy(n=>n).
                 ToArray();
            string oddOrEven = Console.ReadLine().ToLower();
            List<int> result = new List<int>();
            result = ReturnOddEvenColection(inputInterval, oddOrEven, result);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",result));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static List<int> ReturnOddEvenColection(int[] inputInterval, string oddOrEven, List<int> result)
        {
            List<int> allNumbers = new List<int>();
            for (int i = inputInterval[0]; i <= inputInterval[1]; i++)
            {
                allNumbers.Add(i);
            }
            if (oddOrEven == "odd")
            {
                return result = allNumbers.Where(x => x % 2 == 1|| x % 2==-1).ToList();
            }
            else
            {
                return result = allNumbers.Where(x => x % 2 == 0).ToList();
            }
        }
    }
}
