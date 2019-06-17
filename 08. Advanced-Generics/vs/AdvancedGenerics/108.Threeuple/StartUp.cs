using System;
using System.Text;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().
               Split();
            string[] personBeerInfo = Console.ReadLine().
                Split();
            string[] numbersInfo = Console.ReadLine().
                Split();
            string personName = personInfo[0] + " " + personInfo[1];
            string personAdres = personInfo[2];
            string personTown=string.Empty;
            for (int i = 3; i < personInfo.Length; i++)
            {
                personTown += personInfo[i];
            }
            ThreeupleMy<string, string, string> personInfoThreeuple = new ThreeupleMy<string, string, string>(personName, personAdres, personTown);
            Console.WriteLine(personInfoThreeuple.GetInfo());

            string personBeerName = personBeerInfo[0];
            int personAmountBeer = int.Parse(personBeerInfo[1]);
            bool drinkOrNot = (personBeerInfo[2] == "drunk") ? true : false;
            ThreeupleMy<string, int, bool> personBeerInfoThreeuple = new ThreeupleMy<string, int, bool>(personBeerName, personAmountBeer, drinkOrNot);
            Console.WriteLine(personBeerInfoThreeuple.GetInfo());


            string numbersInfoName = numbersInfo[0];
            double numbersInfoDouble = double.Parse(numbersInfo[1]);
            string numbersBankName = numbersInfo[2];
            ThreeupleMy<string, double, string> numbersInfoIntThreeuple = new ThreeupleMy<string, double, string>(numbersInfoName, numbersInfoDouble, numbersBankName);
            Console.WriteLine(numbersInfoIntThreeuple.GetInfo());


        }
    }
}
