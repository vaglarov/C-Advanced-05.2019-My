namespace _101._Line_Numbers
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\text.txt";
            string resultFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\Result102.txt";

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                using (StreamWriter streamWriter = new StreamWriter(resultFile))
                {
                    var line = streamReader.ReadLine();
                    int countLine = 1;
                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line{countLine}:{line}");
                        countLine++;
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
