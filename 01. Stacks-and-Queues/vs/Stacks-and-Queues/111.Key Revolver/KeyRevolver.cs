namespace _111.Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            List<int> bulletBox = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int[] target = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int budget = int.Parse(Console.ReadLine());
            int bulletCount = 0;
            Queue<int> queueTarget = new Queue<int>();
            FillTargetQueue(target, queueTarget);
            Queue<int> queueBarrel = new Queue<int>(barrelSize);
            ReloadBarrel(bulletBox, barrelSize, queueBarrel);
            Console.ForegroundColor = ConsoleColor.Red;
            while (queueTarget.Count != 0)
            {
                int bulletShot = queueBarrel.Dequeue();
                    bulletCount++;
                var currentTarget = queueTarget.ElementAt(0);
                if (currentTarget >= bulletShot)
                {
                    Console.WriteLine("Bang!");
                    queueTarget.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (queueBarrel.Count == 0 && bulletBox.Count!=0)
                {
                    ReloadBarrel(bulletBox, barrelSize, queueBarrel);
                    
                    Console.WriteLine("Reloading!");
                }
                    if (queueBarrel.Count == 0)
                    {
                        break;
                    }
               
            }
            int leftBullet = queueBarrel.Count + bulletBox.Count;
            int leftMoney = budget - bulletCount * bulletPrice;
            PrintResult(leftMoney, leftBullet, queueTarget);

        }

        private static void PrintResult( int leftMoney,int leftBullet,Queue<int> queueTarget)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (queueTarget.Count!=0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueTarget.Count}");
            }
            else
            {
                Console.WriteLine($"{leftBullet} bullets left. Earned ${leftMoney}");
            }
        }

        private static void ReloadBarrel(List<int> bulletBox, int barrelSize, Queue<int> stackBarrel)
        {
            for (int index = 0; index < barrelSize; index++)
            {
                if (bulletBox.Count == 0)
                {
                    break;
                }
                stackBarrel.Enqueue(bulletBox[0]);
                bulletBox.RemoveAt(0);
            }

        }

        private static void FillTargetQueue(int[] target, Queue<int> queueTarget)
        {
            for (int index = 0; index < target.Length; index++)
            {
                queueTarget.Enqueue(target[index]);
            }
        }
    }
}
