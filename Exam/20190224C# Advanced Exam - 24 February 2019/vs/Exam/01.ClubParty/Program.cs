using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ClubParty
{
    public class Hall
    {
        private List<int> listPeople;
        public Hall(int capacity, string name, bool isFull = false)
        {
            Capacity = capacity;
            Name = name;
            listPeople = new List<int>();
            IsFull = isFull;
        }
        public bool IsFull { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public void AddPeople(int people)
        {
            listPeople.Add(people);
        }
        public override string ToString()
        {
            return $"{Name} -> {string.Join(", ", listPeople)}";
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            int capacityHall = int.Parse(Console.ReadLine());
            Stack<string> input = new Stack<string>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<Hall> queueHall = new Queue<Hall>();
            Queue<int> people = new Queue<int>();


            while (input.Count != 0)
            {
                string element = input.Pop();
                int peopleToAdd;
                bool successfullyParsed = int.TryParse(element, out peopleToAdd);
                if (successfullyParsed)
                {
                    if (queueHall.Count>0)
                    {
                    people.Enqueue(peopleToAdd);
                    }
                }
                else
                {
                    string hallSing = element;
                    Hall hall = new Hall(capacityHall, hallSing);
                    queueHall.Enqueue(hall);
                }

            }

            while (queueHall.Count > 0 && people.Count > 0)
            {
                Hall emptyHall = queueHall.Dequeue();
                while (people.Count > 0 && emptyHall.IsFull == false)
                {
                    int currentPeople = people.Peek();
                    if (emptyHall.Capacity - currentPeople >= 0)
                    {
                        people.Dequeue();
                        emptyHall.AddPeople(currentPeople);
                        emptyHall.Capacity -= currentPeople;
                    }
                    //else if (emptyHall.Capacity==0)
                    //{
                    //    emptyHall.IsFull = true;
                    //    Console.WriteLine(emptyHall.ToString());
                    //}
                    else
                    {
                        //people.Dequeue();
                        emptyHall.IsFull = true;
                        Console.WriteLine(emptyHall.ToString());
                    }
                }

            }
        }
    }
}
