using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> dictEngine = new Dictionary<string, Engine>();
            Dictionary<string, Car> dictCar = new Dictionary<string, Car>();

            int numberEngineInput = int.Parse(Console.ReadLine());
            for (int index = 0; index < numberEngineInput; index++)
            {
                string inputEngine = Console.ReadLine();
                AddEngineInCataloginputEngine(inputEngine, dictEngine);
            }
            int numberCarInput = int.Parse(Console.ReadLine());
            for (int index = 0; index < numberCarInput; index++)
            {
                string inputCar = Console.ReadLine();

                AddCarInCatalog(inputCar, dictCar, dictEngine);
            }
            PrintAllCars(dictCar);
        }
        private static void PrintEngine(Dictionary<string, Engine> dictEngine)
        {
            foreach (var engine in dictEngine)
            {
                Console.WriteLine(engine.Value.ToString());
            }
        }

        private static void PrintAllCars(Dictionary<string, Car> dictCar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var car in dictCar)
            {
                Console.WriteLine(car.Value.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddCarInCatalog(string inputCar, Dictionary<string, Car> dictCar, Dictionary<string, Engine> dictEngine)
        {
            string[] inputLine = inputCar.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string carName = inputLine[0];
            if (!dictEngine.ContainsKey(inputLine[1]))
            {
                Console.WriteLine("Engine doesn't exist in engineCatalog!!!");
                return;
            }
            else
            {
                if (!dictCar.ContainsKey(carName))
                {
                    Engine carEngine = dictEngine[inputLine[1]];
                    Car newCar = CarFactory(carName, carEngine, inputLine, dictCar);
                    dictCar.Add(carName, newCar);

                }
            }
        }

        private static Car CarFactory(string carName, Engine carEngine, string[] inputLine, Dictionary<string, Car> dictCar)
        {
            if (inputLine.Length == 2)
            {
                Car newCar = new Car(carName, carEngine);
                return newCar;
            }
            else if (inputLine.Length == 3)
            {
                bool isInt = int.TryParse(inputLine[2], out int weight);
                if (isInt)
                {
                    Car newCar = new Car(carName, carEngine, weight);
                    return newCar;
                }
                else
                {
                    Car newCar = new Car(carName, carEngine, null, inputLine[2]);
                    return newCar;
                }

            }
            else
            {

                int weight = int.Parse(inputLine[2]);
                string color = inputLine[3];
                Car newCar = new Car(carName, carEngine, weight, color);
                return newCar;

            }
        }


        private static void AddEngineInCataloginputEngine(string inputEngine, Dictionary<string, Engine> dictEngine)
        {
            string[] inputLine = inputEngine.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string model = inputLine[0];
            if (!dictEngine.ContainsKey(model))
            {
                Engine newEngine = EngineFactory(inputLine);
                dictEngine.Add(model, newEngine);
            }
        }

        private static Engine EngineFactory(string[] inputLine)
        {
            string model = inputLine[0];
            int power = int.Parse(inputLine[1]);
            if (inputLine.Length == 2)
            {
                Engine newEngine = new Engine(model, power, null, null);
                return newEngine;
            }
            else if (inputLine.Length == 3)
            {
                bool isInt = int.TryParse(inputLine[2], out int displacement);
                if (isInt)
                {
                    Engine newEngine = new Engine(model, power, displacement,null);
                    return newEngine;
                }
                else
                {
                    int? displacementNull = null;
                    string efficiency = inputLine[2];
                    Engine newEngine = new Engine(model, power, displacementNull, efficiency);
                    return newEngine;
                }
            }
            else
            {
                int displacement = int.Parse(inputLine[2]);
                string efficiency = inputLine[3];
                Engine newEngine = new Engine(model, power, displacement, efficiency);
                return newEngine;

            }
        }

    }
}
