namespace _106._Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();
            int specialNumber = int.Parse(Console.ReadLine());
            numbers = numbers.Where(x => x % specialNumber != 0)
                .Reverse()
                .ToList();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ", numbers));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
