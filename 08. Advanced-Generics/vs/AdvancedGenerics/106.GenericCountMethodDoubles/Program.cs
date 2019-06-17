using System;

namespace _106.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLineInput = int.Parse(Console.ReadLine());
            GenericItem<double> elemtsList = new GenericItem<double>();
            for (int i = 0; i < numberLineInput; i++)
            {
                double line = double.Parse(Console.ReadLine());
                elemtsList.Add(line);
            }
            double elementCompare = double.Parse(Console.ReadLine());
            elemtsList.Compare(elementCompare);
            Console.WriteLine(elemtsList.CountGreater);
        }
    }
}
