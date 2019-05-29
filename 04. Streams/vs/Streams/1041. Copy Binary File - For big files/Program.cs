namespace _1041._Copy_Binary_File___For_big_files
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\copyMe.png";
            string destinationFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\copyMeCopyForBigFiles.png";
            using (FileStream streamFile = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream writeFileCopy = new FileStream(destinationFile, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int bytesCount = streamFile.Read(buffer, 0, buffer.Length);
                        if (bytesCount==0)
                        {
                            break;
                        }
                        writeFileCopy.Write(buffer, 0, bytesCount);
                    }
                }
            }
        }
    }
}
