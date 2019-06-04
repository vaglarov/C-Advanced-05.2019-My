namespace _005._Filter_by_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilterByAgegram
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> peopleList = new List<KeyValuePair<string, int>>();
            for (int index = 0; index < peopleCount; index++)
            {
                string[] person = Console.ReadLine().
                    Split(", ", StringSplitOptions.RemoveEmptyEntries);
                peopleList.Add(new KeyValuePair<string, int>(person[0], int.Parse(person[1])));
            }
            string filter = Console.ReadLine();
            int boundaryAge = int.Parse(Console.ReadLine());
            string[] printPattern = Console.ReadLine().Split();

            Console.ForegroundColor = ConsoleColor.Red;
            peopleList.Where(p => filter == "younger" ? p.Value < boundaryAge : p.Value > boundaryAge).
                ToList().
                ForEach(p=>Printer(p,printPattern));
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void Printer(KeyValuePair<string,int> person, string[]printPattern)
        {
           
            if (printPattern.Length==2)
            {
                Console.WriteLine(printPattern[0]=="name"?
                    $"{person.Key} - {person.Value}":
                    $"{person.Value} - {person.Key}" );
            }
            else
            {
                Console.WriteLine(printPattern[0] == "name" ?
                  $"{person.Key}" :
                  $"{person.Value}");
            }
        }
    }
}
