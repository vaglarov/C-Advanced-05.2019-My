namespace _105._Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            /*•	"add"->add 1 to each number
•	"multiply"->multiply each number by 2
•	"subtract"->subtract 1 from each number
•	"print"->print the collection
•	"end"->ends the input*/
            List<int> numbers = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();
            string command;
            while ((command=Console.ReadLine())!="end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x=>x+1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x*2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(string.Join(" ",numbers));
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Wrong input bro!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }


        }
    }
}
