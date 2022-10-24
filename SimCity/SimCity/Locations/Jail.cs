using SimCity.Persons;

namespace SimCity.Locations {
    internal class Jail : Location {
        private List<Person> _inJail;
        private static readonly int _cols = 10;
        private static readonly int _rows = 10;
        private readonly char[,] newFrame = new char[10, 10];
        public override List<Person> Inhabitants { get => _inJail; }
        public override (int rowSize, int colSize) Size { get => (_rows, _cols); }
        public override (int, int) GetRandomPosition() {
            return (_random.Next(1,_rows-1), _random.Next(1, _cols-1));
        }
        public Jail() {
            _inJail = new List<Person>();
            Name = "City Center";
            for (int row = 0; row < _rows; row++) {
                for (int col = 0; col < _cols; col++) {
                    newFrame[row, col] = ' ';
                }
            }
        }
        internal override string GetPrintableString() {
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.y, person.Position.x] = person.Graphics;
            }
            string drawingLine = System.Environment.NewLine;
            drawingLine += new string('*', 12);
            drawingLine += System.Environment.NewLine;
            for (int row = 0; row < newFrame.GetLength(0); row++) {
                drawingLine += "*";
                for (int col = 0; col < newFrame.GetLength(1); col++) {
                    drawingLine += newFrame[row, col].ToString();
                }
                drawingLine += "*";
                drawingLine += System.Environment.NewLine;
            }
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.y, person.Position.x] = ' ';
            }
            drawingLine += "****JAIL****";
            return drawingLine;
        }
    }
}
