namespace CatapultAttack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // ReadInput
            int numberLineInput = int.Parse(Console.ReadLine());
            Queue<int> queueWall = new Queue<int>(
                Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            int numberLineInputWithExtraLine = numberLineInput + numberLineInput / 3;
            Queue<int> tempQueueRock = new Queue<int>();
            Queue<int> queueExtraWall = new Queue<int>();
            for (int i = 1; i <= numberLineInputWithExtraLine; i++)
            {
                if (i % 4 == 0)
                {
                    AddInExtraWall(Console.ReadLine(), queueExtraWall);
                }
                else
                {
                    AddRockInStack(Console.ReadLine(), tempQueueRock);
                }
            }

            Stack<int> stackWall = new Stack<int>(queueWall.Reverse());
            Stack<int> stackRock = new Stack<int>(tempQueueRock.Reverse());


            int round = 1;
            PrintTemp(stackRock, stackWall);

            while (stackRock.Count != 0 && stackWall.Count != 0)
            {
                if (round == 3 && queueExtraWall.Count != 0)
                {
                    int addNewTower = queueExtraWall.Dequeue();
                    int[] tempArr = stackWall.Reverse().ToArray();
                    stackWall.Clear();
                    stackWall.Push(addNewTower);
                    foreach (var item in tempArr)
                    {
                        stackWall.Push(item);
                    }
                    round = 1;
                }
                AttackTower(stackRock, stackWall);
                PrintTemp(stackRock, stackWall);
                round++;
            }
            PrintResult(stackRock, stackWall);

        }

        private static void PrintTemp(Stack<int> stackRock, Stack<int> queueWall)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"stack Rock {string.Join(" ", stackRock)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"stack wall {string.Join(" ", queueWall)}");


        }

        private static void PrintResult(Stack<int> stackRock, Stack<int> queueWall)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (stackRock.Count == 0)
            {
                Console.WriteLine($"Walls left: {string.Join(", ", queueWall)}");
            }
            else
            {
                Console.WriteLine($"Rocks left: {string.Join(", ", stackRock)}");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void AttackTower(Stack<int> rock, Stack<int> wall)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (rock.Count == 0 || wall.Count == 0)
                {
                    break;
                }
                int currentWall = wall.Peek();
                int currentRock = rock.Peek();
                if (currentWall == currentRock)
                {
                    wall.Pop();
                    rock.Pop();
                }
                else if (currentRock > currentWall)
                {
                    int newRock = rock.Pop() - wall.Pop();
                    rock.Push(newRock);
                    
                }
                else
                {
                    int newWall = wall.Pop() - rock.Pop();
                    wall.Push(newWall);
                }
            }
        }

        private static void AddRockInStack(string input, Queue<int> stackRock)
        {
            int[] inputLineSplit = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            stackRock.Reverse();
            foreach (var rock in inputLineSplit.Reverse())
            {
                stackRock.Enqueue(rock);
            }
        }

        private static void AddInExtraWall(string inputLine, Queue<int> queueExtraWall)
        {
            queueExtraWall.Enqueue(int.Parse(inputLine));
        }
    }
}
