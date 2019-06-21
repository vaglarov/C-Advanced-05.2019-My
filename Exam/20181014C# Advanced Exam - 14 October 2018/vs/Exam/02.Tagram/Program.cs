using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Tagram
{
    public class Program
    {
        public class Tagram
        {
            private Dictionary<string, int> tags;
            public string Name { get; set; }
            public int Total => tags.Values.Sum();
            public Tagram(string name, string tag, int likes)
            {
                this.Name = name;
                this.tags = new Dictionary<string, int>();
                tags.Add(tag, likes);
            }
            public void Add(string tag, int likes)
            {
                if (!tags.ContainsKey(tag))
                {
                    tags.Add(tag, likes);
                }
                else
                {
                    tags[tag] += likes;
                }
            }
            public override string ToString()
            {
                StringBuilder mes = new StringBuilder();
                mes.AppendLine(Name);
                foreach (var tags in tags.OrderByDescending(x=>x.Value))
                {
                    mes.AppendLine($"- {tags.Key}: {tags.Value}");
                }
                return mes.ToString();
            }

        }
        static void Main(string[] args)
        {
            Dictionary<string, Tagram> dictTagram = new Dictionary<string, Tagram>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] argssa = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (argssa.Length == 1)
                {
                    var banPerson = input.Split();
                    string person = banPerson[1];
                    dictTagram.Remove(person);
                }
                else
                {

                    string nameTag = argssa[0];
                    string tag = argssa[1];
                    int likes = int.Parse(argssa[2]);
                    if (!dictTagram.ContainsKey(nameTag))
                    {
                        Tagram newTagram = new Tagram(nameTag, tag, likes);
                        dictTagram.Add(newTagram.Name, newTagram);

                    }
                    else
                    {
                        Tagram current = dictTagram[nameTag];
                        current.Add(tag, likes);
                    }
                }

            }
            foreach (var kvp in dictTagram.OrderByDescending(x=>x.Value.Total))
            {
                Console.Write(kvp.Value);
            }
        }
    }
}
