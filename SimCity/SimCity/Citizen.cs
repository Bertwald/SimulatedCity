using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Citizen: Person {
        private List<Item> _belongings = new();
        public override List<Item> Inventory { get { return _belongings; } }

        public override void Move() {
            throw new NotImplementedException();
        }
    }
}
