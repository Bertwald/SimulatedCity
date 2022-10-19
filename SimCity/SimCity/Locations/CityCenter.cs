using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Locations {
    internal class CityCenter : Location {
        private List<Person> _people;
        private static readonly int _cols = 100;
        private static readonly int _rows = 20;
        private readonly char[,] _empty = new char[20, 100];
        public override (int rowSize, int colSize) Size { get => (_rows, _cols); }
        char[,] newFrame = new char[20, 100];

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
                    _empty[row, col] = ' ';
                    newFrame[row, col] = ' ';
                }
            }
        }
        public override List<Person> Inhabitants { get => _people; }
        public override (int, int) GetRandomPosition() {
            return (_random.Next(_rows),_random.Next(_cols));
        }

        internal override string GetPrintableString() {
            //char[,] newFrame = (char[,])_empty.Clone();
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.x, person.Position.y] = person.Graphics;
            }
            string drawingLine = "";
            for (int row = 0; row < newFrame.GetLength(0); row++) {
                for (int col = 0; col < newFrame.GetLength(1); col++) {
                    drawingLine += newFrame[row, col].ToString();
                }
                drawingLine += System.Environment.NewLine;
            }
            foreach (Person person in Inhabitants) {
                newFrame[person.Position.x, person.Position.y] = ' ';
            }
            return drawingLine;
        }
    }
}
