namespace _104.GenericSwapMethodInteger
{
using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            GenericItem<int> elemtsList = new GenericItem<int>();
            for (int i = 0; i < numberLineInput; i++)
            {
                int line = int.Parse(Console.ReadLine());
                elemtsList.Add(line);
            }
            int[] swapIndex = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firsIndex = swapIndex[0];
            int secondIndex = swapIndex[1];
            elemtsList.Swap(firsIndex, secondIndex);
            elemtsList.PrintForeach();

        }
    }
}
