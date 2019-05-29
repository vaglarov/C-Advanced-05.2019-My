namespace _101._Odd_Lines
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader(@"D:\SoftUni\C# Advanced\04. Streams\resurses\text.txt"))
            {
                var line = streamReader.ReadLine();
                int count = 1;
                while (line != null)
                {
                    if (count%2==0)
                    {
                    Console.WriteLine(line);

                    }
                    line = streamReader.ReadLine();
                    count++;
                }
            }
        }
    }
}
