using System;
using System.Linq;

namespace _105.GenericCountMethodStrings
{
    class Program
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
            string elementCompare = Console.ReadLine();
            elemtsList.Compare(elementCompare);
            Console.WriteLine(elemtsList.CountGreater);

        }
    }
}
