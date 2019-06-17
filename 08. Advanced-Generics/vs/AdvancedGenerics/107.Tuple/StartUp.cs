using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().
                Split();
            string[] personBeerInfo= Console.ReadLine().
                Split();
            string[] numbersInfo = Console.ReadLine().
                Split();
            string personName = personInfo[0] + " " + personInfo[1];
            string personTown = personInfo[2];
            TupleMy<string, string> personTupel = new TupleMy<string, string>(personName,personTown);
            Console.WriteLine(personTupel.GetInfo());
            string personBeerName = personBeerInfo[0];
            int personAmountBeer = int.Parse(personBeerInfo[1]);

            TupleMy<string, int> personTupelBeer = new TupleMy<string, int>(personBeerName, personAmountBeer);
            Console.WriteLine(personTupelBeer.GetInfo());

            int numbersInfoInt = int.Parse(numbersInfo[0]);
            double numbersInfoDouble = double.Parse(numbersInfo[1]);
            TupleMy<int, double> numbersInfoTuper = new TupleMy<int, double>(numbersInfoInt, numbersInfoDouble);
            Console.WriteLine(numbersInfoTuper.GetInfo());
        }
    }
}
