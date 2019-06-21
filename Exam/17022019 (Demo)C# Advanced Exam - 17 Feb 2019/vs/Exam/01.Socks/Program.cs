using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            Queue<int> rightSocks=new Queue<int>(Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray());
            List<int> readySocks = new List<int>();
            while (leftSocks.Count!=0&&rightSocks.Count!=0)
            {
                int currentLeft = leftSocks.Peek();
                int currentRigt = rightSocks.Peek();
                if (currentLeft == currentRigt)
                {
                    int tempValue= leftSocks.Pop();
                    leftSocks.Push(tempValue + 1);
                    rightSocks.Dequeue();
                }
                else if (currentLeft>currentRigt)
                {
                    int pair = leftSocks.Pop() + rightSocks.Dequeue();
                    readySocks.Add(pair);
                }
                else
                {
                    leftSocks.Pop();
                }
            }
            Console.WriteLine(readySocks.Max());
            Console.WriteLine(string.Join(" ", readySocks));


        }
    }
}
