using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> dictCarParking;
        private int capacity;
        public Parking(int capacity = 2)
        {
            this.capacity = capacity;
            dictCarParking = new Dictionary<string, Car>(capacity);
        }
        //public int Capacity
        //{
        //    get => capacity;
        //    set => capacity = value;
        //}

        public int Count
        {
            get=> dictCarParking.Count; 
        }
        public string AddCar(Car car)
        {
            if (dictCarParking.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Count == capacity)
            {
                return "Parking is full!";
            }

            dictCarParking.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";


        }

        public string RemoveCar(string registrationNumber)
        {
            if (!dictCarParking.ContainsKey(registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                dictCarParking.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            if (!dictCarParking.ContainsKey(registrationNumber))
            {
                return null;
            }
            else
            {
                Car result = dictCarParking[registrationNumber];
                return result;
            }

        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var car in registrationNumbers)
            {
                 RemoveCar(car);
            }
        }
    }
}
