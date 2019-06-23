using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Astronaut>(capacity);
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public void Add(Astronaut astronaut)
        {
            //if exist ??
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }
        public bool Remove(string name)
        {
            Astronaut current = null;
            foreach (var item in data)
            {
                if (item.Name == name)
                {
                    current = item;
                }
            }
            if (current == null)
            {
                return false;
            }
            else
            {
                int indexCurrent = data.IndexOf(current);
                data.RemoveAt(indexCurrent);
                return true;
            }


        }
        public Astronaut GetOldestAstronaut()
        {
            var oldest = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldest;
        }
        public Astronaut GetAstronaut(string name)
        {
            Astronaut astrName = null;
            foreach (var item in data)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return astrName;
        }
        public int Count => data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {Name}:");
            foreach (var astro in data)
            {
                sb.AppendLine(astro.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
