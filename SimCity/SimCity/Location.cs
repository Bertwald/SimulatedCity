using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class Location {
        private Tuple<int, int> _offset;
        private Tuple<int, int> _size;
        public string Name { get; set; }

        public Location(string name, Tuple<int, int> position, Tuple<int, int> size) {
            Name = name;
            _offset = position;
            _size = size;
        }
    }
    }
