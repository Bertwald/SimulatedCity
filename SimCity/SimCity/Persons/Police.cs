using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;

namespace SimCity.Persons
{
    internal class Police : Person
    {
        public List<Item> _confiscated = new List<Item>();
        public override char Graphics { get => 'P'; }
        public Police(string? name, (int, int) position) : base(name, position) {

        }

        public override List<Item> Inventory { get => _confiscated; }

    }
}
