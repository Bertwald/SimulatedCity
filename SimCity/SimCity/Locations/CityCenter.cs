using SimCity.Persons;

namespace SimCity.Locations {
    internal class CityCenter : Location {
        private List<Person> _people;
        private static readonly int _cols = 109;
        private static readonly int _rows = 19;
        public override (int rowSize, int colSize) Size { get => (_rows, _cols); }
        private readonly char[,] newFrame = new char[19, 109];

        /* Unsafe struct for use if other methods are too slow
        public unsafe struct CharacterContainer {
            private fixed char chars[200];

            public char this[int row, int col] {
                get => this.chars[row*100+col];
                set => this.chars[row * 100 + col] = value;
            }
        }
        */
        public CityCenter() {
            _people = new List<Person>();
            Name = "City Center";
            for (int row = 0; row < _rows; row++) {
                for (int col = 0; col < _cols; col++) {
                    newFrame[row, col] = ' ';
                }
            }
        }
        public override List<Person> Inhabitants { get => _people; }
        public override (int, int) GetRandomPosition() {
            return (_random.Next(1, _rows-1),_random.Next(1, _cols-1));
        }
        //Method will generate console representation of location,
        //cleaning newFrame when done
        internal override string GetPrintableString() {
            //Place all individual graphics at right position
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.x, person.Position.y] = person.Graphics;
            }
            string representation = "";
            //Add a Top Border
            representation += (new string('=', 52) + "SimCity" + new string('=', 52));
            representation += System.Environment.NewLine;
            for (int row = 0; row < newFrame.GetLength(0); row++) {
                //Add contents to representation with each line starting and ending with '|'
                representation += "|";
                for (int col = 0; col < newFrame.GetLength(1); col++) {
                    representation += newFrame[row, col].ToString();
                }
                representation += "|";
                representation += System.Environment.NewLine;
            }
            representation += new string('=', 111);
            //Clean the NewFrame
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.x, person.Position.y] = ' ';
            }
            return representation;
        }
    }
}
