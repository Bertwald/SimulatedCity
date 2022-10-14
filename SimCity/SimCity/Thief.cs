using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Thief: Person {
        private List<Item> _plunder = new List<Item>();
        public List<Item> Item { get { return _plunder; } }
    }
}
