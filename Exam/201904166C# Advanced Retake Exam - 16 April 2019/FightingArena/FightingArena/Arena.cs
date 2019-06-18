using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private Dictionary<string, Gladiator> ators;
        public Arena(string name)
        {
            ators = new Dictionary<string, Gladiator>();
            Name = name;
        }
        public string Name { get; set; }
        public void Add(Gladiator gladiator)
        {

            ators.Add(gladiator.Name, gladiator);
        }
        public void Remove(string name)
        {
                ators.Remove(name);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            var result = ators.Values.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();
            return result;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var result = ators.Values.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();
            return result;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var result = ators.Values.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();
            return result;
        }
        public int Count => ators.Count;
        public override string ToString()
        {
            return $"{Name} - {Count} gladiators are participating.";
        }

    }
}
