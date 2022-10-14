using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal abstract class Person {
        public string? Name { get; set; }
        public char Graphics { get; set; }
        public List<Item> Items { get; init; }


        //Only if prop solution wont work
        /*
        public List<Item> GetItems() {
            return Items;
        }
        */
    }
}
