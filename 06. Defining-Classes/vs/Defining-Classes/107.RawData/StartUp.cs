using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int inputLine = int.Parse(Console.ReadLine());
            List<Car> carCatalog = new List<Car>();
            
            for (int index = 0; index < inputLine; index++)
            {
                string lineInput = Console.ReadLine();
                Car newCar = CarFactory(lineInput);
                carCatalog.Add(newCar);
            }
            string command = Console.ReadLine();
            var result = new List<Car>();
            if (command== "fragile")
            {
                result = carCatalog.Where(car => car.Cargo.Flamable == "fragile").Where(car => car.Tires.TooLowPressure() == true).ToList();
            }
            else if (command=="flamable")
            {
                result = carCatalog.Where(car => car.Cargo.Flamable == "flamable").Where(car=>car.Engine.Power>250).ToList();
            }
            PrintResult(result);

        }

        private static void PrintResult(List<Car> carCatalog)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var car in carCatalog)
            {
                Console.WriteLine(car.Model);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static Car CarFactory(string lineInput)
        {
            string[] lineSplit = lineInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = lineSplit[0];
            //{model} //{engineSpeed} {enginePower} //{cargoWeight} {cargoType}// {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
            //ChevroletAstro //200 180// 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4
            Engine carEngine = EngineFactory(lineSplit[1], lineSplit[2]);
            Cargo carCargo = CargoFactory(lineSplit[3], lineSplit[4]);
            Tires tires = TiresFactory(lineSplit[5], lineSplit[6],
                lineSplit[7], lineSplit[8],
                lineSplit[9], lineSplit[10],
                lineSplit[11], lineSplit[12]);
            Car car = new Car(model, carEngine, carCargo, tires);
            return car;
        }

        private static Tires TiresFactory(string pressureInput, string ageInput,
            string pressure1Input, string age1Input,
            string pressure2Input, string age2Input,
            string pressure3Input, string age3Input)
        {
            double pressure = double.Parse(pressureInput);
            int age = int.Parse(ageInput);
            double pressure1 = double.Parse(pressure1Input);
            int age1 = int.Parse(age1Input);
            double pressure2 = double.Parse(pressure2Input);
            int age2 = int.Parse(age2Input);
            double pressure3 = double.Parse(pressure3Input);
            int age3 = int.Parse(age3Input);
            Tires tires = new Tires(pressure, age,
                pressure1, age1,
                pressure2, age2,
                pressure3, age3);
            return tires;

        }

        private static Cargo CargoFactory(string weightInput, string typeInput)
        {
            int weight = int.Parse(weightInput);
            string type = typeInput;
            Cargo cargo = new Cargo(weight, type);
            return cargo;
        }
        private static Engine EngineFactory(string speedInput, string powerInput)
        {
            int speed = int.Parse(speedInput);
            int power = int.Parse(powerInput);
            Engine engine = new Engine(speed, power);
            return engine;
        }
    }
}
