using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.City
{
    internal class Location
    {
        private (int x, int y) _offset;
        private (int x, int y) _size;
        public string Name { get; set; }

        public Location(string name, (int, int) position, (int, int) size)
        {
            Name = name;
            _offset = position;
            _size = size;
        }
        internal (int, int) GetRandomPosition() {
            Random random = new();
            return (random.Next(_size.x), random.Next(_size.y));
        }
    }
}
