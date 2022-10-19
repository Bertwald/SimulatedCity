using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimCity.Items;
using SimCity.Locations;

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
        internal static (int , int) GetDirectionTuple(Directions direction) => direction switch {
            Directions.North => (-1, 0),
            Directions.NorthEast => (-1, 1),
            Directions.East => (0, 1),
            Directions.SouthEast => (1, 1),
            Directions.South => (1, 0),
            Directions.SouthWest =>(1, -1),
            Directions.West => (0, -1),
            Directions.NorthWest => (-1, -1),
            _ => (0, 0),
        };
        internal Directions GetRandomDirection() {
            Random random = new Random();
            return (Directions)random.Next((int)Directions.Max);
        }
        internal (int, int) GetRandomDirectionTuple() {
            return GetDirectionTuple(GetRandomDirection());
        }
        internal Person(string? name, Location home, (int, int) position) {
            Random random = new();
            Home = home;
            Name = name;
            xPos = position.Item1;
            yPos= position.Item2;
            _direction = GetRandomDirectionTuple();
            _bounds = home.Size;
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        internal Person(Location home, (int, int) position) {
            Home = home;
            Name = "NPC";
            xPos = position.Item1;
            yPos = position.Item2;
            _direction = GetRandomDirectionTuple();
            _bounds = home.Size;
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        internal Person(string? name, Location home, (int x, int y) position, (int x, int y) direction) {
            Name = name;
            Home = home;
            xPos = position.x;
            yPos = position.y;
            _direction = direction;
            _bounds = home.Size;
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }

        public string? Name { get; set; }
        public Location Home { get; set; }
        //public (int x, int y) Position { get; set; }
        public (int x, int y) Position { get => (xPos, yPos);}
        private int xPos;
        private int yPos;
        private (int x, int y) _direction;
        private (int x, int y) _bounds;
        public abstract char Graphics { get; }
        public abstract List<Item> Inventory { get; init; }
        public virtual void Move() {
            xPos += _direction.x;
            yPos += _direction.y;
            if (xPos < 0) {
                xPos += _bounds.x;
            }
            if (yPos < 0) {
                yPos += _bounds.y;
            }
            if (xPos >= _bounds.x) {
                xPos -= _bounds.x;
            }
            if (yPos >= _bounds.y) {
                yPos -= _bounds.y;
            }
            /*
            Position = (Position.x + _direction.x , Position.y + _direction.y);
            if(Position.x < 0) {
                Position = (Position.x+_bounds.x, Position.y);
            }if (Position.y < 0) {
                Position = (Position.x, Position.y + _bounds.y);
            } if (Position.x >= _bounds.x) {
                Position = (Position.x - _bounds.x, Position.y);
            } if (Position.y >= _bounds.y) {
                Position = (Position.x, Position.y - _bounds.y);
            }
            */
        }

        //Only if prop solution wont work
        /*
        public List<Item> GetInventory() {
            return Inventory;
        }
        */
    }
}
