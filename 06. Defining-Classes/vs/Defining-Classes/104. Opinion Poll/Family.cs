namespace DefiningClasses
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    public class Family
    {
        List<Person> familyListField = new List<Person>();

        public List<Person> FamilyList { get => familyListField; set => familyListField = value; }
        public Family()
        {
            FamilyList = familyListField;
        }

        public void AddMember(Person person)
        {
                this.FamilyList.Add(person);
        }

        public Person GetOldestMember()
        {
            return FamilyList.OrderByDescending(person => person.Age).FirstOrDefault();
        }

        public void AddOpinionPerson(Person person)
        {
            if (person.Age > 30 && !this.FamilyList.Contains(person))
            {
                this.FamilyList.Add(person);
            }
        }

        public List<Person> GetAllFamilyMember()
        {
            return this.FamilyList.ToList();
        }

    }
}
