namespace _107._Predicate_For_Names
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int maxNameLenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToList();
            names = names.Where(nameLenght => nameLenght.Length <= maxNameLenght).
                ToList();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
