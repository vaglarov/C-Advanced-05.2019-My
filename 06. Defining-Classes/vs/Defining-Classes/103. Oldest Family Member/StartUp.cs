namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            int familyMembers = int.Parse(Console.ReadLine());
            Family currentFamily = new Family();
            for (int index = 0; index < familyMembers; index++)
            {
                Person newFamilyMember = CreateMember();
                currentFamily.AddMember(newFamilyMember);
            }

            var oldestFamilyMember = currentFamily.GetOldestMember();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(oldestFamilyMember.ToString());
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
