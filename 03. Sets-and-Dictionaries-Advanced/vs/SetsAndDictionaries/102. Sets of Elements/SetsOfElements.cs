namespace _102._Sets_of_Elements
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] sizeSets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            HashSet<int> hashSetFirst = new HashSet<int>();
            HashSet<int> hashSetSecond = new HashSet<int>();
            FillSetWihtValue(sizeSets[0], hashSetFirst);
            FillSetWihtValue(sizeSets[1], hashSetSecond);
            List<int> intersect = hashSetFirst.Intersect(hashSetSecond).ToList();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",intersect));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void FillSetWihtValue(int numberElements, HashSet<int> hashSetFirst)
        {
            for (int index = 0; index < numberElements; index++)
            {
                int currentElement = int.Parse(Console.ReadLine());
                if (!hashSetFirst.Contains(currentElement))
                {
                    hashSetFirst.Add(currentElement);
                }
            }
        }
    }
}
