using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;
        private int id;
        public Repository()
        {
            data = new Dictionary<int, Person>();
            id = 0;
        }
        public int Count => this.data.Count;
        public void Add(Person person)
        {
            data.Add(this.id, person);
            this.id++;
        }
        public Person Get(int id)
        {
            //if exist?
            return this.data[id];
        }
        public bool Update(int id, Person newPerson)
        {
            if (!this.data.ContainsKey(id))
            {
                return false;
            }
            this.data.Remove(id);
            this.data.Add(id, newPerson);
            return true;
        }

        public bool Delete(int id)
        {
            if (!this.data.ContainsKey(id))
            {
                return false;
            }
            this.data.Remove(id);
            return true;
        }
    }
}

