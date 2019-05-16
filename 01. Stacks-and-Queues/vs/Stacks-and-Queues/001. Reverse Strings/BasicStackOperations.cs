namespace _001._Reverse_Strings
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] inputElemenSplit = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberElementToPush = inputElemenSplit[0];
            int numberElementToPop = inputElemenSplit[1];
            int seachingNumberr = inputElemenSplit[2];
            Stack<int> stackNumbers = new Stack<int>(numberElementToPush);
            AddElementsInStack(stackNumbers, numberElementToPush);
            PopElementsFromStack(stackNumbers, numberElementToPop);

            //check if searching number is in stack and print result
            Console.ForegroundColor = ConsoleColor.Red;
            if (LookForNumber(stackNumbers, seachingNumberr))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestEmenentInStack = SmallestElementInStack(stackNumbers);
                Console.WriteLine(smallestEmenentInStack);
            }


        }

        private static int SmallestElementInStack(Stack<int> stackNumbers)
        {
            int result = int.MaxValue;
            if (stackNumbers.Count==0)
            {
                result = 0;
            }
            while (stackNumbers.Count!=0)
            {
                int currentElement = stackNumbers.Pop();
                if (currentElement<result)
                {
                    result = currentElement;
                }
            }
            return result;
        }

        private static bool LookForNumber(Stack<int> stackNumbers, int seachingNumber)
        {
            if (stackNumbers.Contains(seachingNumber))
            {
                return true;
            }
            return false;
        }

        private static void PopElementsFromStack(Stack<int> stackNumbers, int numberElementToPop)
        {
            for (int index = 0; index < numberElementToPop; index++)
            {
                stackNumbers.Pop();
            }
        }

        private static void AddElementsInStack(Stack<int> stackNumbers, int numberElementToPush)
        {
            int[] elemntsToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < elemntsToAdd.Length; i++)
            {
                stackNumbers.Push(elemntsToAdd[i]);
            }
        }
    }
}
