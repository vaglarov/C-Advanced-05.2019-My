namespace GenericSwapMethodString
{
using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            GenericItem<string> elemtsList = new GenericItem<string>();
            for (int i = 0; i < numberLineInput; i++)
            {
                string line = Console.ReadLine();
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
