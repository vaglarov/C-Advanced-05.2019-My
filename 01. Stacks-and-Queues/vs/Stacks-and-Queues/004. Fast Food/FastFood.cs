namespace _004._Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityFoodForDay = int.Parse(Console.ReadLine());
            int[] orderInputArray = Console.ReadLine().Split().
                Select(int.Parse).
                ToArray();
            Queue<int> queue = new Queue<int>();
            FillQueueWithOrders(queue, orderInputArray);
            int maxOrder = queue.Max();
            while (queue.Count != 0)
            {
                int currentOrder = queue.Dequeue();
                if (currentOrder <= quantityFoodForDay)
                {
                    quantityFoodForDay -= currentOrder;
                }
                else
                {
                    queue.Enqueue(currentOrder);
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(maxOrder);
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                var leftOrder = queue.ToList();
                var lastElement = leftOrder[leftOrder.Count - 1];
                leftOrder.Insert(0, lastElement);
                leftOrder.RemoveAt(leftOrder.Count - 1);

                Console.WriteLine($"Orders left: {string.Join(" ", leftOrder)}");
            }
        }

        private static void FillQueueWithOrders(Queue<int> queue, int[] orderInputArray)
        {
            for (int i = 0; i < orderInputArray.Length; i++)
            {
                queue.Enqueue(orderInputArray[i]);
            }
        }
    }
}
