namespace _002._Sum_Numbers
{
    using System;
    using System.Linq;

    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                 Split(", ", StringSplitOptions.RemoveEmptyEntries).
                 Select(Parser).
                 ToArray();
            int countArray = numbers.Count();
            int sumArray = numbers.Sum();
            Console.WriteLine(countArray);
            Console.WriteLine(sumArray);
        }

        public static Func<string, int> Parser = n => int.Parse(n);
    }
}

