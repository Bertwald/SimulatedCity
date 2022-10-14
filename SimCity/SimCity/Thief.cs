using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Thief: Person {
        private List<Item> _plunder = new List<Item>();
        public override List<Item> Inventory { get { return _plunder; } }
        public override void Move() {
            throw new NotImplementedException();
        }
    }
}
