namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> dictCar = new Dictionary<string, Car>();
            int numberInputCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInputCars; i++)
            {
                string line = Console.ReadLine();
                CarFatory(line, dictCar);
            }
            string command;
            while ((command=Console.ReadLine())!= "End")
            {
                Travel(command, dictCar);
            }
            PrintResult(dictCar);
        }

        private static void PrintResult(Dictionary<string, Car> dictCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var car in dictCar)
            {
                Console.WriteLine(car.Value.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Travel(string command, Dictionary<string, Car> dictCar)
        {
            string[] commandSplit = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string carModel = commandSplit[1];
            int travelDistance = int.Parse(commandSplit[2]);
            if (dictCar.ContainsKey(carModel))
            {
                var travelCar = dictCar[carModel];
                travelCar.Drive(travelDistance);
            }
            else
            {
                Console.WriteLine("Тhis car does not exis in dataBase!!!!");
            }
        }

        private static void CarFatory(string line, Dictionary<string, Car> dictCar)
        {
            string[] lineSplit = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = lineSplit[0];
            double fuelAmount = double.Parse(lineSplit[1]);
            double fuelConsumption = double.Parse(lineSplit[2]);
            if (!dictCar.ContainsKey(model))
            {
                Car newCar = new Car(model, fuelAmount, fuelConsumption);
                dictCar.Add(model, newCar);
            }
        }
    }
}
