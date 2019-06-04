using System;
using System.Linq;

namespace _004._Add_VAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).
                Select(number => number * 1.2).
                ToArray();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var price in prices)
            {
                Console.WriteLine(price.ToString("F2"));
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
