using System;
using System.Collections.Generic;

namespace _007._Pascal_Triangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int numberStepsInPiramid = int.Parse(Console.ReadLine());
            var dictPaskalPiramid = new Dictionary<int, List<int>>();
            for (int stepFromTop = 0; stepFromTop < numberStepsInPiramid; stepFromTop++)
            {
                var newLine = new List<int>();
                //Creat and add top of piramids
                if (stepFromTop == 0)
                {
                    newLine.Add(1);
                    dictPaskalPiramid.Add(0, newLine);
                }
                else
                {
                    var stepBefore = dictPaskalPiramid[stepFromTop - 1];
                    for (int index = 0; index <= stepBefore.Count; index++)
                    {
                        if (index == 0)
                        {
                            newLine.Add(1);
                        }
                        else if (index == stepBefore.Count)
                        {
                            newLine.Add(1);
                        }
                        else
                        {
                            var newElement = stepBefore[index] + stepBefore[index - 1];
                            newLine.Add(newElement);
                        }
                    }
                    dictPaskalPiramid.Add(stepFromTop, newLine);
                }
            }
            //Print Piramid
            bool color = true;
            foreach (var step in dictPaskalPiramid)
            {
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Join("\t", step.Value));
                    color = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(string.Join("\t", step.Value));
                    color = true;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
