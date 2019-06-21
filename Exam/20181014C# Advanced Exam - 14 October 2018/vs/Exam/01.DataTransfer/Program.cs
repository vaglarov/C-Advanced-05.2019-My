using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.DataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string patturnName = @"[^A-z\s]";
            string patturSender = @"s:(?<name>[^\;]*);";
            string patturResiver = @"r:(?<reviver>[^\;]*);";
            string patturMessage = "m--\"(?<message>[^\"]*)";
            int numberLineInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberLineInput; i++)
            {
                int totalTransfer = 0;
                string lineInput = Console.ReadLine();
                var senderCript = Regex.Match(lineInput, patturSender);
                if (senderCript!=null)
                {
                    var sender = senderCript.Groups["name"].Value;
                    totalTransfer += CountDigits(sender);
                    var senderRealName = Regex.Replace(sender, patturnName, "");
                    var resiverCript = Regex.Match(lineInput, patturResiver);
                    if (resiverCript != null)
                    {
                        var resiver = resiverCript.Groups["reviver"].Value;
                        totalTransfer += CountDigits(resiver);
                        var resiverRealName = Regex.Replace(resiver, patturnName, "");

                        var resiverMess = Regex.Match(lineInput, patturMessage);
                        if (resiverMess!=null)
                        {
                        var message = resiverMess.Groups["message"].Value;

                            Console.WriteLine($"{senderRealName} says \"{ message}\" to {resiverRealName}");
                            Console.WriteLine($"Total data transferred: {totalTransfer}MB");

                        }


                    }
                }


            }



        }

        private static int CountDigits(string sender)
        {
            int result = 0;
            string patternDigits = @"\d";
            var resultRegex = Regex.Matches(sender, patternDigits);
            foreach (Match item in resultRegex)
            {
                result += int.Parse(item.ToString());
            }
            return result;
        }
    }
}
