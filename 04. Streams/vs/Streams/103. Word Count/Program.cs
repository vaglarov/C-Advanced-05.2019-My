namespace _103._Word_Count
{
using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string sourceFileWords = @"D:\SoftUni\C# Advanced\04. Streams\resurses\words.txt";
            string sourceFileText = @"D:\SoftUni\C# Advanced\04. Streams\resurses\text.txt";
            var dictWordsFromTextDoc = new Dictionary<string, int>();
            //Read words and add in Dictionary
            using (StreamReader streamWord = new StreamReader(sourceFileWords))
            {
                var lineWord = streamWord.ReadLine();
                while (lineWord!=null)
                {
                    if (!dictWordsFromTextDoc.ContainsKey(lineWord))
                    {
                        dictWordsFromTextDoc.Add(lineWord, 0);
                    }
                    lineWord = streamWord.ReadLine();
                }
            }
            //Read text and check for word
            using (StreamReader streamText = new StreamReader(sourceFileText))
            {

                var lineWord = streamText.ReadLine();
                while (lineWord != null)
                {
                    lineWord = lineWord.ToLower();
                    string patternWord = @"[a-z]+";
                    var regexMatch = Regex.Matches(lineWord, patternWord);
                    foreach (Match word in regexMatch)
                    {
                        if (dictWordsFromTextDoc.ContainsKey(word.Value))
                        {
                            dictWordsFromTextDoc[word.Value]++;
                        }
                    }
                    lineWord = streamText.ReadLine();
                }
            }

            //Export dictionary in text file
            string resultFile = @"D:\SoftUni\C# Advanced\04. Streams\resurses\Result103.txt";
            using (StreamWriter streamTextWrite = new StreamWriter(resultFile))
            {
                foreach (var kvp in dictWordsFromTextDoc.OrderByDescending(x=>x.Value))
                {
                    streamTextWrite.WriteLine($"{kvp.Key}-{kvp.Value}");
                }

            }
        }
    }
}
