using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Locations {
    internal class Jail : Location {
        private List<Person> _inJail;
        private static readonly int _cols = 10;
        private static readonly int _rows = 10;
        private char[,] _empty = new char[10, 10];
        public override List<Person> Inhabitants { get => _inJail; }
        public override (int rowSize, int colSize) Size { get => (_rows, _cols); }

        public override (int, int) GetRandomPosition() {
            return (_random.Next(_rows), _random.Next(_cols));
        }
        public Jail() {
            _inJail = new List<Person>();
            Name = "City Center";
            for (int row = 0; row < _rows; row++) {
                for (int col = 0; col < _cols; col++) {
                    _empty[row, col] = ' ';
                }
            }
        }
        internal override string GetPrintableString() {
            char[,] newFrame = (char[,])_empty.Clone();
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.y, person.Position.x] = person.Graphics;
            }
            string drawingLine = "";
            for (int row = 0; row < newFrame.GetLength(0); row++) {
                for (int col = 0; col < newFrame.GetLength(1); col++) {
                    drawingLine += newFrame[row, col].ToString();
                }
                drawingLine += System.Environment.NewLine;
            }
            return drawingLine;
        }
    }
}
