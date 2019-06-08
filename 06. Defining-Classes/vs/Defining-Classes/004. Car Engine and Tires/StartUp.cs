namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1,1.0),
                new Tire(1,1),
                new Tire(1,1),
                new Tire(1,1)
            };
            var engine = new Engine(100, 2.2);

            string make = "AUDI";
            string model = "A3";
            int year = 1998;
            double fuelQuantity = 65;
            double fuelConsumption = 16;
            Car newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);
            Car lamboCar = new Car("Lambo", "Urus",2010,250,9,engine, tires); 
        }
    }
}
