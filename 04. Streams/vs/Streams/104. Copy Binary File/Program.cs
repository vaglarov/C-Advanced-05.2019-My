namespace _104._Copy_Binary_File
{
using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\copyMe.png";
            string destinationFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\copyMeCopy.png";
            using (FileStream streamFile=new FileStream(sourceFile, FileMode.Open) )
            {
                var size = streamFile.Length;
                byte[] buffer = new byte[size];
                streamFile.Read(buffer, 0, buffer.Length);
                using (FileStream writeFileCopy = new FileStream(destinationFile, FileMode.Create))
                {
                    writeFileCopy.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
