namespace _003._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int numberCommands = int.Parse(Console.ReadLine());
            Stack<int> stackNumber = new Stack<int>();

            for (int indexCommand = 0; indexCommand < numberCommands; indexCommand++)
            {
                int[] lineInput = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                switch (lineInput[0])
                {
                    case 1://Add elememt in stack
                        int newElement = lineInput[1];
                        stackNumber.Push(newElement);
                        break;
                    case 2: //delete first element in stack
                        if (stackNumber.Count() > 0)
                        {
                            stackNumber.Pop();
                        }
                        break;
                    case 3://Print max element
                        if (stackNumber.Count() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            int maxElement = stackNumber.Max();
                            Console.WriteLine(maxElement);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 4://Print mix element
                        if (stackNumber.Count() > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            int minElement = stackNumber.Min();
                            Console.WriteLine(minElement);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }

            }
            int[] result = stackNumber.ToArray();
            Console.ForegroundColor = ConsoleColor.Red;
            if (result.Count() > 0)
            {
                Console.WriteLine(string.Join(", ", result));
            }
        }
    }
}
