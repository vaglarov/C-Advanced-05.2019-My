namespace _102.GenericBoxOfInteger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> newBox = new Box<int>(input);
                Console.WriteLine(newBox);

            }
        }
    }
}
