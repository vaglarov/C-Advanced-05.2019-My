using System;

namespace _101.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                string input = Console.ReadLine();
                Box<string> newBox = new Box<string>(input);
                Console.WriteLine(newBox);

            }
        }
    }
}
