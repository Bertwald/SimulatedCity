﻿using SimCity.Locations;
using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events {
    internal class Reclamation : Event {
        public Reclamation(Person one, Person theOther, int row, int col, List<Location> locations) : base(one, theOther, row, col, locations) {
        }
    }
}
