namespace DefiningClasses
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    public class Family
    {
        private List<Person> familyListField;

        public Family()
        {
            familyListField = new List<Person>();
        }

        public void AddMember(Person person)
        {
               this.familyListField.Add(person);
        }

        public Person GetOldestMember()
        {
            return familyListField.OrderByDescending(person=>person.Age).FirstOrDefault();
        }
    }
}
