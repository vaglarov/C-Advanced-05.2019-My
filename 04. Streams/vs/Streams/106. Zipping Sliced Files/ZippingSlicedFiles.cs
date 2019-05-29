namespace _106._Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    class ZippingSlicedFiles
    {
        static List<string> listParts;
        static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\sliceMe.mp4";
            string destinationDirectory = @"D:\SoftUni\C# Advanced\04. Streams\resurses\";
            int parts = 4;
            listParts = new List<string>(parts);
            Slice(sourceFile, destinationDirectory, parts);
            Assemble(listParts, destinationDirectory);
        }
        //Slice mp4 format to 4 pieces
        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream fileStreamRead = new FileStream(sourceFile, FileMode.Open))
            {
                var totalLenght = fileStreamRead.Length;
                var sizePart = totalLenght / parts + totalLenght % parts;
                byte[] buffer = new byte[sizePart];
                for (int i = 0; i < parts; i++)
                {
                    string destinationDirectoryPart = destinationDirectory + $" Part {i}.mp4";
                    listParts.Add(destinationDirectoryPart);
                    using (FileStream writeNewFile = new FileStream(destinationDirectoryPart, FileMode.Create))
                    {

                        fileStreamRead.Read(buffer, 0, buffer.Length);
                        writeNewFile.Write(buffer, 0, buffer.Length);
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(destinationDirectoryPart + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream writeFile = new FileStream(destinationDirectory + "Assemble.mp4", FileMode.Create))
            {
                foreach (var file in files)
                {
                    byte[] buffer;
                    using (FileStream readFile = new FileStream(file, FileMode.Open))
                    {
                        var size = readFile.Length;
                        buffer = new byte[size];
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(file + ".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        gz.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer);
                    }
                }
            }

        }
    }
}

