using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events {
    internal class NullEvent : Event {
        public NullEvent(Person one, Person theOther, int row, int col) : base(one, theOther, row, col) {
        }
    }
}
