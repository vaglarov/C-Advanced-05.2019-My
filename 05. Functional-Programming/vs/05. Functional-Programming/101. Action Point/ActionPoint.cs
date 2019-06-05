using System;
using System.Collections.Generic;
using System.Linq;

namespace _101._Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().
                Split(" ",StringSplitOptions.RemoveEmptyEntries).
                ToList();
            names.ForEach(n => Print(n));
        }
        private static void Print(string name)
        {
            Console.WriteLine(name);
        }
    }
}
