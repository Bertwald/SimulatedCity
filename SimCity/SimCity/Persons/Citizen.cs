using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;

namespace SimCity.Persons
{
    internal class Citizen : Person
    {
        private List<Item> _belongings = new();

        public Citizen(string? name, (int, int) position) : base(name, position) {

        }

        public override List<Item> Inventory { get { return _belongings; } }
    }
}
