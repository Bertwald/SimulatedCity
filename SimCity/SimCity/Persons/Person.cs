using SimCity.Items;
using SimCity.Locations;
using System.Security.Cryptography.X509Certificates;

namespace SimCity.Persons
{
    internal abstract class Person
    {
        //------------------------------------------------------------------------------------------------------------
        //                                            non-person stuff
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
        internal static Directions GetRandomDirection() {
            Random random = new Random();
            return (Directions)random.Next((int)Directions.Max);
        }
        internal static (int, int) GetRandomDirectionTuple() {
            return GetDirectionTuple(GetRandomDirection());
        }
        //------------------------------------------------------------------------------------------------------------
        internal Person(Location home, (int, int) position) {
            Home = home;
            Name = "NPC";
            xPos = position.Item1;
            yPos = position.Item2;
            _direction = GetRandomDirectionTuple();
            _bounds = home.Size;
        }
        public string? Name { get; set; }
        public Location Home { get; set; }
        public (int x, int y) Position { get => (xPos, yPos); set => (xPos, yPos) = value; }
        private int xPos;
        private int yPos;
        private (int x, int y) _direction;
        private (int x, int y) _bounds;
        public abstract char Graphics { get; }
        public abstract List<Item> Inventory { get; protected set; }
        public virtual void Move() {
            xPos = (xPos + _bounds.x + _direction.x) % _bounds.x;
            yPos = (yPos + _bounds.y + _direction.y) % _bounds.y;
        }
        internal void SetHome(Location location) {
            if (location == null) {
                return;
            } else {
                Home = location;
                _bounds = Home.Size;
                Position = Home.GetRandomPosition();
                _direction = GetRandomDirectionTuple();
            }
        }
        internal void SetDirection((int x, int y) newdirection) {
            if(newdirection != (0, 0)) {
                _direction = newdirection;
            }
        }
        //Gets the person as in the new output of wednesday 19/10
        internal string GetPersonInfo() {
            return "";
        }
    }
}
