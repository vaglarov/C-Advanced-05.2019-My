namespace _110.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                ToList();
            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandArr = command.Split();

                Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
                Func<string, string, bool> endWithFilter = (name, param) => name.EndsWith(param);

                switch (commandArr[0])
                {
                    case "Remove":
                        if (commandArr[1] == "StartsWith")
                        {
                            names.RemoveAll(name => startsWithFilter(name, commandArr[2]));
                        }
                        else if (commandArr[1] == "EndsWith")
                        {
                            names.RemoveAll(name => endWithFilter(name, commandArr[2]));
                        }
                        else if (commandArr[1] == "Length")
                        {
                            int lenghtName = int.Parse(commandArr[2]);
                            names.RemoveAll(name => name.Length== lenghtName);
                        }
                        break;
                    case "Double":
                        if (commandArr[1] == "StartsWith")
                        {
                            var coppyNames = names.Where(name => startsWithFilter(name, commandArr[2])).ToList();

                            names = DoubleNames(names, coppyNames);
                        }
                        else if (commandArr[1] == "EndsWith")
                        {
                            var coppyNames = names.Where(name => endWithFilter(name, commandArr[2])).ToList();
                            names = DoubleNames(names, coppyNames);
                        }
                        else if (commandArr[1] == "Length")
                        {
                            int lenghtName = int.Parse(commandArr[2]);
                            var coppyNames = names.Where(name => name.Length == lenghtName).ToList();
                            names = DoubleNames(names, coppyNames);

                        }
                        break;
                    default:
                        Console.WriteLine("Wrong input bro!");
                        break;
                }
            }
            PrintResult(names);

        }

        private static void PrintResult(List<string> names)
        {
            if (names.Count != 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nobody is going to the party!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static List<string> DoubleNames(List<string> names, List<string> coppyNames)
        {
            foreach (var name in coppyNames)
            {
                for (int index = 0; index < names.Count; index++)
                {
                    if (name == names[index])
                    {
                        names.Insert(index, name);
                        break;
                    }
                }
            }
            return names;
        }
    }
}
