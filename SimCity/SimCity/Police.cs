using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Police: Person {
        public List<Item> _confiscated = new List<Item>();
        public List<Item> Item { get { return _confiscated; } }
    }
}
