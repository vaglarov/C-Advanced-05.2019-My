using System;
using System.Linq;

namespace _104.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake newLakeTest = new Lake(test);
            Console.WriteLine(string.Join(", ", newLakeTest));
        }
    }
}
