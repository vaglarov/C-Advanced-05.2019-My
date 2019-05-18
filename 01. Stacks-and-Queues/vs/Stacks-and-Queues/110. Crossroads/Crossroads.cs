namespace _110._Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightTimer = int.Parse(Console.ReadLine());
            int yeollowTimer = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int countPassCar = 0;
            bool haveCrash = false;
            Queue<string> queueCars = new Queue<string>();
            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    queueCars.Enqueue(command);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    int leftTime = greenLightTimer;
                    while (leftTime > 0&&queueCars.Count!=0)
                    {
                        var car = queueCars.Dequeue();
                        if ((leftTime + yeollowTimer) < car.Length)
                        {
                            leftTime = leftTime + yeollowTimer;
                            char inpact = car[leftTime];
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {inpact}.");
                            haveCrash = true;
                            break;
                        }

                        leftTime -= car.Length;

                        countPassCar++;
                    }


                    if (haveCrash)
                    {
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (haveCrash==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countPassCar} total cars passed the crossroads.");
            }
        }

    }
}
