namespace _005._Special_Cars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<List<Tire>> tiresIndex = new List<List<Tire>>();
            List<Engine> engineIndex = new List<Engine>();
            List<Car> carCatalog = new List<Car>();
            //Add tire in tiresIndex
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] commandArr = command.Split();
                List<Tire> tires = new List<Tire>();
                for (int i = 0; i < commandArr.Length; i += 2)
                {
                    int tireYear = int.Parse(commandArr[i]);
                    double tirePreassure = double.Parse(commandArr[i + 1]);
                    Tire newTire = new Tire(tireYear, tirePreassure);
                    tires.Add(newTire);
                }
                tiresIndex.Add(tires);
            }
            //Add engine int engineIndex
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] commandArr = command.Split();
                int horesPower = int.Parse(commandArr[0]);
                double cubicCapacity = double.Parse(commandArr[1]);
                Engine newEngine = new Engine(horesPower, cubicCapacity);
                engineIndex.Add(newEngine);
            }
            //Add car in CarCatalog
            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] commandArr = command.Split();
                //BMW X5 2007 175 18 1 1
                string manufacture = commandArr[0];
                string model = commandArr[1];
                int year = int.Parse(commandArr[2]);
                double fuelQuantity = double.Parse(commandArr[3]);
                double fuelConsumption = double.Parse(commandArr[4]);
                int indexTire = int.Parse(commandArr[5]);
                Tire[] currentTires = tiresIndex[indexTire].ToArray();
                int indexEngine = int.Parse(commandArr[6]);
                Engine currentEngine = engineIndex[indexEngine];
                Car newCar = new Car(manufacture, model, year, fuelQuantity, fuelConsumption, currentEngine, currentTires);
                carCatalog.Add(newCar);
            }
            List<Car> specilaCar = new List<Car>();
            specilaCar = SelectSpecilalCar(carCatalog);
            PrintResult(specilaCar);

        }

        private static void PrintResult(List<Car> specilaCar)
        {
            if (specilaCar.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No special car!!!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                foreach (var car in specilaCar)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }

        private static List<Car> SelectSpecilalCar(List<Car> carCatalog)
        {
            List<Car> result = new List<Car>();
            result = carCatalog.Where(car => car.Drive(20)).ToList();
            result = result.Where(car => car.Year >= 2017)
                .Where(car => car.Engine.HorsePower >= 330)
                .Where(car => car.TirePresure() >= 9 && car.TirePresure() <= 10)
                .ToList();

            return result;
        }
    }
    class Tire
    {
        private int year;
        private double pressure;
        public int Year { get => year; set => year = value; }
        public double Pressure { get => pressure; set => pressure = value; }

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

    }
    class Engine
    {
        private int horsePower;
        private double cubicCapacity;
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double CubicCapacity { get => cubicCapacity; set => cubicCapacity = value; }
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    class Car
    {
        private string make = "VW";
        private string model = "Golf";
        private int year = 2025;
        private double fuelQuantity = 200;
        private double fuelConsumption = 10;
        private Engine engine;
        private Tire[] tires;
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }


        public Engine Engine { get => engine; set => engine = value; }

        public Tire[] Tires { get => tires; set => tires = value; }

        public Car()
        {
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
         : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public double TirePresure()
        {
            List<Tire> tires = Tires.ToList();
            double result = 0;
            foreach (var tire in tires)
            {
                result += tire.Pressure;
            }
            return result;
        }
        public bool Drive(int distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption / 100) >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= distance * this.FuelConsumption / 100;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();

        }
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return $"Make: {Make}{Environment.NewLine}" +
             $"Model: {Model}{Environment.NewLine}" +
             $"Year: {Year}{Environment.NewLine}" +
             $"HorsePowers: {Engine.HorsePower}{Environment.NewLine}" +
             $"FuelQuantity: {FuelQuantity}";
        }

    }

}
