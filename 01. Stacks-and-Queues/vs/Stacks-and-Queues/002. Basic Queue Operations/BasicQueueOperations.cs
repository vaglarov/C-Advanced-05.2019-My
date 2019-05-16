namespace _002._Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            int[] inputElemenSplit = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberElementToEnqueue = inputElemenSplit[0];
            int numberElementToDequeue = inputElemenSplit[1];
            int seachingNumberr = inputElemenSplit[2];
            Queue<int> queueNumbers = new Queue<int>(numberElementToEnqueue);
            AddElementsInQueue(queueNumbers, numberElementToEnqueue);
            DequeElementsFromStack(queueNumbers, numberElementToDequeue);

            //check if searching number is in stack and print result
            Console.ForegroundColor = ConsoleColor.Red;
            if (LookForNumber(queueNumbers, seachingNumberr))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestEmenentInQueue = SmallestElementInQueue(queueNumbers);
                Console.WriteLine(smallestEmenentInQueue);
            }


        }

        private static int SmallestElementInQueue(Queue<int> queue)
        {
            int result = int.MaxValue;
            if (queue.Count == 0)
            {
                result = 0;
            }
            while (queue.Count != 0)
            {
                int currentElement = queue.Dequeue();
                if (currentElement < result)
                {
                    result = currentElement;
                }
            }
            return result;
        }

        private static bool LookForNumber(Queue<int> queue, int seachingNumber)
        {
            if (queue.Contains(seachingNumber))
            {
                return true;
            }
            return false;
        }

        private static void DequeElementsFromStack(Queue<int> queue, int numberElementToPop)
        {
            for (int index = 0; index < numberElementToPop; index++)
            {
                queue.Dequeue();
            }
        }

        private static void AddElementsInQueue(Queue<int> queue, int numberElementToPush)
        {
            int[] elemntsToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < elemntsToAdd.Length; i++)
            {
                queue.Enqueue(elemntsToAdd[i]);
            }
        }
    }
}
