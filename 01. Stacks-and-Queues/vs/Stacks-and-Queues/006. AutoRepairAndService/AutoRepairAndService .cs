namespace _006._AutoRepairAndService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            Queue<string> queueService = new Queue<string>();
            Stack<string> stackServiceCar = new Stack<string>();
            AddCarInQueue(inputLine, queueService);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitCommand = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                switch (splitCommand[0])
                {
                    case "Service":
                        ServiceCar(queueService, stackServiceCar);
                        break;
                    case "CarInfo":
                        string searchingCar = splitCommand[1];
                        CarInfo(queueService, stackServiceCar, searchingCar);
                        break;
                    case "History":
                        HistoryServise(stackServiceCar);
                        break;
                    default:
                        Console.WriteLine("Wrong input bro");
                        break;
                }
            }
            PrintResult(queueService, stackServiceCar);
        }

        private static void PrintResult(Queue<string> queueService, Stack<string> stackServiceCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] queue = queueService.ToArray();
            if (queue.Length > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queue)}");

            }
            string[] stack = stackServiceCar.ToArray();
            Console.WriteLine($"Served vehicles: {string.Join(", ", stack)}");
        }

        private static void HistoryServise(Stack<string> stackServiceCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] historyServise = stackServiceCar.ToArray();
            Console.WriteLine(string.Join(", ", historyServise));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void CarInfo(Queue<string> queue, Stack<string> stack, string searchingCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (queue.Contains(searchingCar))
            {
                Console.WriteLine("Still waiting for service.");
            }
            else if (stack.Contains(searchingCar))
            {
                Console.WriteLine($"Served.");
            }
            else
            {
                Console.WriteLine("Don't know bro:)");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private static void ServiceCar(Queue<string> queueService, Stack<string> stackServiceCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (queueService.Count != 0)
            {
                string firstCarOnQueue = queueService.Dequeue();
                Console.WriteLine($"Vehicle {firstCarOnQueue} got served.");
                stackServiceCar.Push(firstCarOnQueue);

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddCarInQueue(string inputLine, Queue<string> waithngService)
        {
            string[] cars = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < cars.Length; index++)
            {
                waithngService.Enqueue(cars[index]);
            }
        }
    }
}
