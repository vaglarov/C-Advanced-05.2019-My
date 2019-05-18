
namespace _007._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TruckTour
    {
        static void Main(string[] args)
        {
            int numberStation = int.Parse(Console.ReadLine());
            Queue<int[]> queueStation = new Queue<int[]>();
            FillQueueStation(numberStation, queueStation);
            int startCircular = FindStartStation(queueStation);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(startCircular);
        }

        private static int FindStartStation(Queue<int[]> queueStation)
        {
            int startIndex = 0;
            int totalFuel = 0;
            while (totalFuel <= 0)
            {
                foreach (var petrolStation in queueStation)
                {
                    int fuel = petrolStation[0];
                    int distance = petrolStation[1];
                    totalFuel += fuel - distance;
                    if (totalFuel < 0)
                    {
                        queueStation.Enqueue(queueStation.Dequeue());
                        startIndex++;
                        totalFuel = 0;
                        break;
                    }
                }
            }
            return startIndex;




        }

        private static void FillQueueStation(int numberStation, Queue<int[]> queueStation)
        {
            for (int index = 0; index < numberStation; index++)
            {
                int[] inputLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();
                queueStation.Enqueue(inputLine);
            }
        }
    }
}
