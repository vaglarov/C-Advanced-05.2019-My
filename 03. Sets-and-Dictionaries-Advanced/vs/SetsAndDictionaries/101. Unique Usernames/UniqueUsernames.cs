namespace _101._Unique_Usernames
{
    using System;
    using System.Collections.Generic;
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());

            HashSet<string> setName = new HashSet<string>();
            for (int index = 0; index < numberInput; index++)
            {
                string nameInput     = Console.ReadLine();
                if (!setName.Contains(nameInput))
                {
                    setName.Add(nameInput);
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var name in setName)
            {
                Console.WriteLine(name);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
