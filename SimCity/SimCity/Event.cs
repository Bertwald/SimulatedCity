﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    //Events need to be subclassed for the static counter to work properly
    internal class Event {
        private Tuple<Person, Person> _persons;
        private ConsoleColor _color;
        public Event(Person one, Person theOther) {
            _persons = new Tuple<Person, Person>(one, theOther);
        }
        public Person getFirstPerson() {
            return _persons.Item1;
        }
        public Person getLastPerson() {
            return _persons.Item2;
        }
        public override string ToString() {
            return "";
        }
    }
}