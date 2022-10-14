using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal abstract class Person {
        public string? Name { get; set; }
        public char Graphics { get; set; }
        public abstract List<Item> Inventory { get;}

        public abstract void Move();
        //Only if prop solution wont work
        /*
        public List<Item> GetInventory() {
            return Inventory;
        }
        */
    }
}
