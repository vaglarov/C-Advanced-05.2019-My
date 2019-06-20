using System;
using System.Linq;

namespace _101.ListyIterator
{
   public  class Program
    {
        static void Main(string[] args)
        {
            string input;
            ListyIterator<string> listIterator =null;
            while ((input=Console.ReadLine())!= "END")
            {
                try
                {
                    if (input.Contains("Create"))
                    {
                        var elements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).
                            Skip(1).
                            ToList();
                        listIterator = new ListyIterator<string>(elements);
                    }
                    else if (input=="HasNext")
                    {
                        Console.WriteLine(listIterator.HasNext());
                    }
                    else if (input == "Move")
                    {
                        Console.WriteLine(listIterator.Move());
                    }
                    else if (input == "Print")
                    {
                        listIterator.Print();
                    }
                   

                }
                catch ( Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
