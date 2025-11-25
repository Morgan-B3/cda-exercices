using System;
using System.Collections.Generic;
using System.Text;

namespace ExoPOO1.Classes
{
    internal class Chaise
    {
        private int _feetNumber;
        private string? _material;
        private string? _color;

        public int FeetNumber { get { return _feetNumber; } set { _feetNumber = value; } }
        public string Material { get { return _material; } set { _material = value; } }
        public string Color { get { return _color; } set { _color = value; } }

        public Chaise()
        {
            FeetNumber = 4;
            Color = "Rouge";
            Material = "Bois";
        }

        public Chaise(int feetNumber, string material, string color)
        {
            FeetNumber = feetNumber;
            Material = material;
            Color = color;
        }

        public void Informations()
        {
            Console.WriteLine($"La chaise {Color} possède {FeetNumber} pieds en {Material}");
        }
    }
}
