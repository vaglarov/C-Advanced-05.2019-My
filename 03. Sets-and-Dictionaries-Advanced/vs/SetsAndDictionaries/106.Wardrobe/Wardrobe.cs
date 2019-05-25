namespace _106._Wardrobe
{
    using System;
    using System.Collections.Generic;

    class Wardrobe
    {
        static void Main(string[] args)
        {
            var dictWadrobe = new Dictionary<string, Dictionary<string, int>>();
            var numberLineInput = int.Parse(Console.ReadLine());
            //Fill dictionary
            for (int i = 0; i < numberLineInput; i++)
            {
                var separator = new string[] { " -> ", "," };
                var inputSplitLine = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                var colorBox = inputSplitLine[0];
                if (!dictWadrobe.ContainsKey(colorBox))
                {
                    dictWadrobe.Add(colorBox, new Dictionary<string, int>());
                }
                for (int index = 1; index < inputSplitLine.Length; index++)
                {
                    var itemToAdd = inputSplitLine[index];
                    if (!dictWadrobe[colorBox].ContainsKey(itemToAdd))
                    {
                        dictWadrobe[colorBox].Add(itemToAdd, 1);
                    }
                    else
                    {
                        dictWadrobe[colorBox][itemToAdd]++;
                    }

                }
            }

            var itemToFind = Console.ReadLine().Split();
            //Print result
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var colorBox in dictWadrobe)
            {
                Console.WriteLine($"{colorBox.Key} clothes:");
                foreach (var typeOfDress in colorBox.Value)
                {
                    if (itemToFind[0] == colorBox.Key && itemToFind[1] == typeOfDress.Key)
                    {
                        Console.WriteLine($"* {typeOfDress.Key} - {typeOfDress.Value} (found!)");
                    }
                    else
                    {

                        Console.WriteLine($"* {typeOfDress.Key} - {typeOfDress.Value}");
                    }
                }
            }
        }
    }
}
