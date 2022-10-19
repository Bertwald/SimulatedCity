using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Locations
{
    internal abstract class Location {
        //Unused
        //private (int x, int y) _offset;
        protected static Random _random = new();
        public string? Name { get; init; }
        public abstract (int rowSize, int colSize) Size { get; }
        public abstract List<Person> Inhabitants { get; }
        public abstract (int, int) GetRandomPosition();
        public virtual void AddPerson(Person person) {
            Inhabitants.Add(person);
        }
        public virtual void RemovePerson(Person person) {
            Inhabitants.Remove(person);
        }
        internal abstract string GetPrintableString();
    }
}
