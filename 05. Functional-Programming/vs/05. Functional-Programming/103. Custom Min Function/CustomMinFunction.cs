namespace _103._Custom_Min_Function
{
using System;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int smallestNumber = Smallest(numbers);
            Console.WriteLine(smallestNumber);
        }

        private static int Smallest(int[] numbers)
        {
            return numbers.Min();
        }
    }
}
