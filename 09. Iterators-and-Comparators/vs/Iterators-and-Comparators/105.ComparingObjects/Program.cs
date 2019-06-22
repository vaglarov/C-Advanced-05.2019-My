using System;
using System.Collections.Generic;

namespace _105.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input=Console.ReadLine())!="END")
            {
                string[] peopleArg = input.Split();
                string namePerson = peopleArg[0];
                int agePerson = int.Parse(peopleArg[1]);
                string townPerson = peopleArg[2];
                Person person = new Person(namePerson, agePerson, townPerson);
                people.Add(person);

            }
            int indexPerson = int.Parse(Console.ReadLine());
            Person etalonPerson = people[indexPerson - 1];
            int countMatches = 1;
            int countNotEqualPeople = 0;
            int tootalPeople = people.Count;
            foreach (var currentPerson in people)
            {
                if (currentPerson!= etalonPerson)
                {
                    if (currentPerson.CompareTo(etalonPerson)==0)
                    {
                        countMatches++;
                    }
                    else
                    {
                        countNotEqualPeople++;
                    }
                    
                }
               
            }
            if (countMatches==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countMatches} {countNotEqualPeople} {tootalPeople}");
            }
        }
    }
}
