using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            Stack<int> bottels = new Stack<int>(Console.ReadLine().
               Split(" ", StringSplitOptions.RemoveEmptyEntries).
               Select(int.Parse).
               ToArray());
            int wastedWater = 0;
            while (cups.Count>0&&bottels.Count>0)
            {
                int cupQuantity = cups.Dequeue();
                int bottelQuantity = bottels.Pop();
                cupQuantity -= bottelQuantity;
                while (cupQuantity>0&& bottels.Count > 0)
                {
                    int newBotterl = bottels.Pop();
                    cupQuantity-= newBotterl;
                }
                wastedWater += (-1) * cupQuantity;
            }
            if (cups.Count>0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottels)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }

    }
}
