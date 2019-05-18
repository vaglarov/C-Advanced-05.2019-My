
namespace _112._Cups_and_Bottles
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            //Read Inputs
            int[] arrCupsCap = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            Queue<int> queueCupsLine = new Queue<int>();
            FillQueueCups(arrCupsCap, queueCupsLine);

            int[] arrbottle= Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            Stack<int> stackBottles = new Stack<int>();
            FillStack(arrbottle, stackBottles);

            int wastedWather = CalculateWastedWather(wastedWather=0, queueCupsLine, stackBottles); ;
            
            Print(wastedWather, queueCupsLine, stackBottles);
            
        }

        private static void Print(int wastedWather, Queue<int> queueCupsLine, Stack<int> stackBottles)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (queueCupsLine.Count!=0)
            {
                Console.WriteLine($"Cups: {string.Join(' ',queueCupsLine)}");
            }
            if (stackBottles.Count!=0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ',stackBottles)}");
            }
          
            Console.WriteLine($"Wasted litters of water: {wastedWather}");
        }

        private static int CalculateWastedWather(int wastedWather, Queue<int> queueCupsLine, Stack<int> stackBottles)
        {
            int lastCup = 0;
            while (queueCupsLine.Count!=0 &&
                stackBottles.Count!=0)
            {
                if (lastCup==0)
                {
                    lastCup = queueCupsLine.Dequeue();
                    int currentBottle = stackBottles.Pop();
                    if (lastCup<=currentBottle)
                    {
                        wastedWather += currentBottle - lastCup;
                        lastCup = 0;
                    }
                    else
                    {
                        lastCup = lastCup - currentBottle;
                    }
                }
                else
                {
                    int currentBottle = stackBottles.Pop();
                    if (lastCup <= currentBottle)
                    {
                        wastedWather += currentBottle - lastCup;
                        lastCup = 0;
                    }
                    else
                    {
                        lastCup = lastCup - currentBottle;
                    }
                }

            }
            return wastedWather;
        }

        private static void FillStack(int[] arrbottle, Stack<int> stackBottles)
        {
            for (int index = 0; index < arrbottle.Length; index++)
            {
                stackBottles.Push(arrbottle[index]);
            }
        }

        private static void FillQueueCups(int[] arrCupsCap, Queue<int> queueCupsLine)
        {
            for (int index = 0; index < arrCupsCap.Length; index++)
            {
                queueCupsLine.Enqueue(arrCupsCap[index]);
            }
        }
    }
}
