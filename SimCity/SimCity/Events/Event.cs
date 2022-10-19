using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Persons;

namespace SimCity.Events
{
    internal class Event
    {
        private Tuple<Person, Person> _persons;
        public virtual ConsoleColor Color { get; }
        public virtual int NumberOfInstances { get; }
        public int Row { get; init; }
        public int Col { get; init; }
        public virtual char Symbol { get; }
        public Event(Person one, Person theOther, int row, int col)
        {
            _persons = new Tuple<Person, Person>(one, theOther);
            Row = row;
            Col = col;
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

        internal static Event Create((Person first, Person second) pair) {
            if(pair.second is Police) {
                //return new Arrest();
            }
            if (pair.second is Citizen) {
                //return new Theft();
            }
            return new NullEvent(pair.first, pair.second,150,150);
        }
    }
}
