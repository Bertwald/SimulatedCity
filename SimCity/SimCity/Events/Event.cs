using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using SimCity.Events;
using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class Event {
        private Tuple<Person, Person> _persons;
        protected List<Location> _locations;
        public virtual ConsoleColor Color { get; }
        public virtual int NumberOfInstances { get; }
        public int Row { get; init; }
        public int Col { get; init; }
        public virtual char Symbol { get; }
        public Event(Person one, Person theOther, int row, int col, List<Location> locations) {
            _persons = new Tuple<Person, Person>(one, theOther);
            Row = row;
            Col = col;
            _locations = locations;
        }
        public Person getFirstPerson() {
            return _persons.Item1;
        }
        public Person getLastPerson() {
            return _persons.Item2;
        }
        public ConsoleColor getColor() {
            return Color;
        }
        public virtual void ResolveEvent() {
            //Console.WriteLine("Derpy Resolution of Event");
        }

        //internal static Event Create((Person first, Person second) pair, List<Location> locations) {
        //    if (pair.first is Thief && pair.second is Police) {
        //        return new Arrest(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations);
        //    }
        //    if (pair.first is Thief && pair.second is Citizen) {
        //        return new Theft(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations);
        //    }
        //    if (pair.first is Thief && pair.second == pair.first) {
        //        return new Amnesty(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations);
        //    }
        //    if (pair.first is Police && pair.second is Citizen) {
        //        return new Reclamation(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations);
        //    }
        //    return new NullEvent(pair.first, pair.second, 150, 150, locations);
        //}

        internal static Event Create((Person first, Person second) pair, List<Location> locations) => pair switch {
            (Thief, Police) => new Arrest(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations),
            (Thief, Citizen) => new Theft(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations),
            (Thief, Thief) when pair.first == pair.second => new Amnesty(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations),
            (Police, Citizen) => new Reclamation(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations),
            _ => new NullEvent(pair.first, pair.second, pair.first.Position.x, pair.first.Position.y, locations),
        };
        internal virtual string GetEventString() {
            return "Derpy description of event";
        }
    }
}
