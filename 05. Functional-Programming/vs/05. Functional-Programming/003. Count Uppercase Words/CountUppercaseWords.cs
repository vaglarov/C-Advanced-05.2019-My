namespace _003._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    class CountUppercaseWords
    { 
        static void Main(string[] args)
        {
            string[] upperWord = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Where(w => Char.IsUpper(w[0])).
                ToArray();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(Environment.NewLine,upperWord));
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}
