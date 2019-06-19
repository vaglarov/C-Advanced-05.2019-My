using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private Dictionary<string, Hero> data;
        public HeroRepository()
        {
            data = new Dictionary<string, Hero>();
        }
        public void Add(Hero hero)
        {
            //if exist?
            data.Add(hero.Name, hero);
        }
        public void Remove(string name)
        {
            data.Remove(name);
        }
        public Hero GetHeroWithHighestStrength()
        {
            var result = data.Values.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
            return result;
        }
        public Hero GetHeroWithHighestAbility()
        {
            var result = data.Values.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
            return result;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var result = data.Values.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
            return result;
        }

        public int Count => data.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in data.Values)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString();
        }
    }
}

