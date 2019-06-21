using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Tagram
{
    //Katty -> healthy -> 50
    class Tagram
    {
        private Dictionary<string, int> tags;
        public string Name { get; set; }
        public Tagram(string name, string tag,int likes)
        {
            this.Name = name;
            tags = new Dictionary<string, int>();
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

    }
}
