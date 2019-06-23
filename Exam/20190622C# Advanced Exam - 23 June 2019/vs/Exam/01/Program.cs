using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> matirialPoint = new Dictionary<string, int>();
            Dictionary<string, int> matirialCurrentPoint = new Dictionary<string, int>();
            AddMatirulaInBothDict(matirialPoint, matirialCurrentPoint);
            Queue<int> liquidQueue = new Queue<int>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            Stack<int> itemStack = new Stack<int>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            while (itemStack.Count>0&&liquidQueue.Count>0)
            {
                int currentLiquid = liquidQueue.Dequeue();
                int curredntItem = itemStack.Pop();
                int sum = currentLiquid + curredntItem;
                if (matirialPoint.ContainsValue(sum))
                {
                    var myKey = matirialPoint.FirstOrDefault(x => x.Value == sum).Key;
                    matirialCurrentPoint[myKey]++;
                }
                else
                {
                    curredntItem += 3;
                    itemStack.Push(curredntItem);
                }
            }
            bool haveShip = false;
            var result= matirialCurrentPoint.Where(x => x.Value == 0).ToArray();
            if (result.Length==0)
            {
                haveShip = true;
            }
            if (haveShip)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
                if (liquidQueue.Count==0)
                {
                    Console.WriteLine("Liquids left: none");
                }
                else
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquidQueue)}");
                }
                if (itemStack.Count==0)
                {
                    Console.WriteLine("Physical items left: none");
                }
                else
                {
                    Console.WriteLine($"Physical items left: {string.Join(", ", itemStack)}");
                }

                foreach (var item in matirialCurrentPoint.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
                if (liquidQueue.Count == 0)
                {
                    Console.WriteLine("Liquids left: none");
                }
                else
                {
                    Console.WriteLine($"Liquids left: {string.Join(", ", liquidQueue)}");
                }
                if (itemStack.Count == 0)
                {
                    Console.WriteLine("Physical items left: none");
                }
                else
                {
                    Console.WriteLine($"Physical items left: {string.Join(", ", itemStack)}");
                }
                foreach (var item in matirialCurrentPoint.OrderByDescending(x => x.Value).OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }

        private static void AddMatirulaInBothDict(Dictionary<string, int> matirialPoint, Dictionary<string, int> matirialCurrentPoint)
        {
                matirialPoint.Add("Aluminium", 50);
            matirialCurrentPoint.Add("Aluminium", 0);

            matirialPoint.Add("Glass", 25);
            matirialCurrentPoint.Add("Glass", 0);

            matirialPoint.Add("Lithium", 75);
            matirialCurrentPoint.Add("Lithium", 0);

            matirialPoint.Add("Carbon fiber", 100);
            matirialCurrentPoint.Add("Carbon fiber", 0);
        }
    }
}
