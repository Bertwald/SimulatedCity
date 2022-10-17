using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimCity.Items;

namespace SimCity.Persons
{
    internal abstract class Person
    {
        internal enum Directions {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest,
            Max
        }
        internal (int , int) GetDirectionTuple(Directions direction) => direction switch {
            Directions.North => (0, 1),
            Directions.NorthEast => (1, 1),
            Directions.East => (1, 0),
            Directions.SouthEast => (1, -1),
            Directions.South => (0, -1),
            Directions.SouthWest =>(-1, -1),
            Directions.West => (-1, 0),
            Directions.NorthWest => (-1, 1),
            _ => (0, 0),
        };
        internal Directions GetRandomDirection() {
            Random random = new Random();
            return (Directions)random.Next((int)Directions.Max);
        }
        internal (int, int) GetRandomDirectionTuple() {
            return GetDirectionTuple(GetRandomDirection());
        }
        internal Person(string? name, (int, int) position) {
            Random random = new();
            Name = name;
            this.Position = position;
            _direction = GetRandomDirectionTuple();
        }
        internal Person((int, int) position) {
            Name = "NPC";
            this.Position = position;
            _direction = GetRandomDirectionTuple();
        }
        public string? Name { get; set; }
        public (int x, int y) Position { get; set; }
        private (int x, int y) _direction;
        public abstract char Graphics { get; }
        public abstract List<Item> Inventory { get; }
        public virtual void Move() {
            Position = (Position.x + _direction.x , Position.y + _direction.y);
        }

        //Only if prop solution wont work
        /*
        public List<Item> GetInventory() {
            return Inventory;
        }
        */
    }
}
