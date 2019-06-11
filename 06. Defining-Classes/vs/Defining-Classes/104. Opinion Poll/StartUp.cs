namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            Family opinionPeople = new Family();
            for (int index = 0; index < familyMembers; index++)
            {
                Person newFamilyMember = CreateMember();
                opinionPeople.AddOpinionPerson(newFamilyMember);
            }

            PrintFamilyMember(opinionPeople);
        }

        private static void PrintFamilyMember(Family opinionPeople)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var person in opinionPeople.GetAllFamilyMember().OrderBy(person=>person.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static Person CreateMember()
        {
            string[] lineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = lineInput[0];
            int personAge = int.Parse(lineInput[1]);
            Person newMember = new Person(personName, personAge);
            return newMember;
        }
    }
}
