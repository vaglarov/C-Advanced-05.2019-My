namespace _111.PartyReservaFilterModule
{
using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProgrPartyReservaFilterModuleam
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().
                 Split();
            List<string> filters = new List<string>();
            string filter;
            while ((filter=Console.ReadLine())!= "Print")
            {
                string[] filterArr = filter.Split(";");
                string action = filterArr[0];
                if(action=="Add filter")
                {
                    filters.Add($"{filterArr[1]};{filterArr[2]}");
                }
                else if (action=="Remove filter")
                {
                    filters.Remove($"{filterArr[1]};{filterArr[2]}");
                }

            }

            Func<string,int, bool> lenghtFilter = (name,lenght) => name.Length ==lenght;
            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endWithFilter = (name, param) => name.EndsWith(param);
            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);

            foreach (var currentFilter in filters)
            {
                string[] currentFilterInfo = currentFilter.Split(";");
                string action = currentFilterInfo[0];
                string param = currentFilterInfo[1];

                if (action=="Starts with")
                {
                    names=names.Where(name=>!startsWithFilter(name,param)).ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(name => !startsWithFilter(name, param)).ToArray();
                }
                else if (action=="Length")
                {
                    int length = int.Parse(param);
                    names = names.Where(name => !lenghtFilter(name, length)).ToArray();
                }
                else if (action=="Contains")
                {
                    names = names.Where(name => !containsFilter(name, param)).ToArray();

                }
            } 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(' ',names));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
