using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Police: Person {
        public List<Item> _confiscated = new List<Item>();
        public override List<Item> Inventory { get { return _confiscated; } }

        public override void Move() {
            throw new NotImplementedException();
        }
    }
}
