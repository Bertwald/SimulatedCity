using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Persons;

namespace SimCity.Events
{
    //Events need to be subclassed for the static counter to work properly
    internal class Event
    {
        private Tuple<Person, Person> _persons;
        public ConsoleColor Color { get; set; }
        public virtual int NumberOfInstances { get; }
        public Event(Person one, Person theOther)
        {
            _persons = new Tuple<Person, Person>(one, theOther);
        }
        public Person getFirstPerson()
        {
            return _persons.Item1;
        }
        public Person getLastPerson()
        {
            return _persons.Item2;
        }
        public ConsoleColor getColor()
        {
            return Color;
        }
        public virtual void ResolveEvent()
        {
            Console.WriteLine("Derpy Resolution of Event");
        }
    }
}
