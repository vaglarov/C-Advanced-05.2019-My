namespace _108.CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomComparator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();
            List<int> sortNumbers = CustomComparatorMethod(numbers);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",sortNumbers));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static List<int> CustomComparatorMethod(List<int> numbers)
        {
            List<int> result = new List<int>();
            List<int> oddNumbers = numbers.Where(x => x % 2 == 1||x%2==-1)
                .OrderBy(x=>x)
                .ToList();
            List<int> evenNumbers= numbers.Where(x => x % 2 == 0 )
                   .OrderBy(x => x)
                   .ToList();
            result.AddRange(evenNumbers);
            result.AddRange(oddNumbers);

            return result;
        }
    }
}
