namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person first = new Person();
            Person second = new Person(13);
            Person third = new Person("Inan", 65);
            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
            Console.WriteLine(third.ToString());
        }
    }
}
