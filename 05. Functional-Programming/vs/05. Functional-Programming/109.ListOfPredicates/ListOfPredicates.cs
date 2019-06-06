namespace _109.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int endSequence = int.Parse(Console.ReadLine());
            List<int> numbers = CreatSequence(endSequence);
            List<int> predicateNumbers = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries).
                 Select(int.Parse).
                 ToList();
            List<int> resultSequence = numbers.Where(x => DivisionPredicate(x,predicateNumbers)).
                ToList();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ", resultSequence));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool DivisionPredicate(int number,List<int> predicateNumbers)
        {
            foreach (var predicate in predicateNumbers)
            {
                if (number%predicate!=0)
                {
                    return false;
                }
            }
            return true;
        }

        private static List<int> CreatSequence(int endSequence)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= endSequence; i++)
            {
                result.Add(i);
            }
            return result;
        }
       
    }
}
