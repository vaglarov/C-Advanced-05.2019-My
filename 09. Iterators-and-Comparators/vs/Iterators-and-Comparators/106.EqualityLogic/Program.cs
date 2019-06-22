using System;
using System.Collections.Generic;

namespace _106.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbereLineInput = int.Parse(Console.ReadLine());
            HashSet<Person> hashSetPerson = new HashSet<Person>();
            SortedSet<Person> sortedSetPerson = new SortedSet<Person>();
            for (int i = 0; i < numbereLineInput; i++)
            {
                string[] argsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string namePerson = argsInput[0];
                int agePerson = int.Parse(argsInput[1]);
                Person newPerson = new Person(namePerson, agePerson);
                hashSetPerson.Add(newPerson);
                sortedSetPerson.Add(newPerson);
            }
            Console.WriteLine(hashSetPerson.Count);
            Console.WriteLine(sortedSetPerson.Count);
        }
    }
}
