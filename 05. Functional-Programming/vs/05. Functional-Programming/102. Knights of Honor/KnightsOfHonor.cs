namespace _102._Knights_of_Honor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().
                 Split(" ", StringSplitOptions.RemoveEmptyEntries).
                ToList();


            names.ForEach(n => Print(n));

        }
        private static void Print(string name)
        {
            Console.WriteLine($"Sir {name}");
        }
        private static void AddSir(string name)
        {
            name += "Sir";
        }

    }
}
