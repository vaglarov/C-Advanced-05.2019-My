 namespace _1._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                Where(x => x % 2 == 0).
                OrderBy(x => x)));
        }
    }
}
