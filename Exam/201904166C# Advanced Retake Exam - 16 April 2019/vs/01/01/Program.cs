using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberWave = int.Parse(Console.ReadLine());
            Stack<int> stackPaletes = new Stack<int>();
            int allWave = numberWave / 3 + numberWave;
            AddPaletesInStack(stackPaletes);
            Stack<Stack<int>> stackRockets = new Stack<Stack<int>>();
            List<int> extraPale = new List<int>();
            AddRockedsInStack(stackRockets, extraPale, allWave);
            Attack(stackRockets, stackPaletes, extraPale);
            PrintResult(stackRockets, stackPaletes);
        }

        private static void PrintResult(Stack<Stack<int>> stackRockets, Stack<int> stackPaletes)
        {
            if (stackPaletes.Count()!=0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", stackPaletes)}");
            }
            else
            {
                var result = stackRockets.Pop();
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", result)}");
            }
        }

        private static void Attack(Stack<Stack<int>> stackRockets, Stack<int> stackPaletes, List<int> extraPale)
        {
            while (stackPaletes.Count != 0)
            {
                for (int wave = 1; wave <= 3; wave++)
                {
                  //  PrintTemp(stackPaletes, stackRockets);
                    if (wave == 3 && extraPale.Count != 0)
                    {
                        int newPale = extraPale.First();
                        stackPaletes.Reverse();
                        stackPaletes.Push(newPale);
                        stackPaletes.Reverse();
                    }
                    for (int i = 0; i < 3; i++)
                    {

                        if (stackRockets.Count == 0)
                        {
                            return;
                        }
                        else
                        {
                            Stack<int> currentStackRocket = stackRockets.Pop();
                            var currentRocket = currentStackRocket.Peek();
                            var currentPale = stackPaletes.Peek();
                            if (currentRocket == currentPale)
                            {
                                currentStackRocket.Pop();
                                stackPaletes.Pop();
                            }
                            else if (currentRocket < currentPale)
                            {
                                var dmg = stackPaletes.Pop() - currentStackRocket.Pop();
                                stackPaletes.Push(dmg);
                            }
                            else
                            {
                                var newRocket = currentStackRocket.Pop() - stackPaletes.Pop();
                                currentStackRocket.Push(newRocket);
                            }
                            if (currentStackRocket.Count() != 0)
                            {

                                stackRockets.Push(currentStackRocket);
                            }
                        }
                    }
                }

            }
        }

        private static void PrintTemp(Stack<int> stackPaletes, Stack<Stack<int>> stackRockets)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Pale  {string.Join(", ", stackPaletes)}");
            foreach (var wave in stackRockets)
            {
                Console.WriteLine($"Wave   {string.Join(" ", wave)}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AddRockedsInStack(Stack<Stack<int>> stackRockets, List<int> extraPale, int allWave)
        {
            List<Stack<int>> tempList = new List<Stack<int>>();
            for (int i = 1; i <= allWave; i++)
            {
                if (i % 4 == 0)
                {
                    int extraTower = int.Parse(Console.ReadLine());
                    extraPale.Add(extraTower);
                }
                else
                {

                    Stack<int> newWave = new Stack<int>(Console.ReadLine().
                        Split().
                        Select(int.Parse).
                        ToArray());
                    tempList.Add(newWave);
                }
            }
            for (int i = tempList.Count() - 1; i >= 0; i--)
            {
                stackRockets.Push(tempList[i]);
            }


        }

        private static void AddPaletesInStack(Stack<int> stackPaletes)
        {
            int[] lineInput = Console.ReadLine().Split().
                 Select(int.Parse)
                 .ToArray().
                 Reverse()
                 .ToArray();
            foreach (var pale in lineInput)
            {
                stackPaletes.Push(pale);
            }
        }
    }
}
