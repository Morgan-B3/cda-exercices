using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Classes
{
    internal class Triangle : Figure
    {
        public double Base { get; set; }
        public double Hauteur { get; set; }

        public Triangle(double _base, double hauteur, double posX, double posY)
        {
            Base = _base;
            Hauteur = hauteur;
            Origine = new Point(posX, posY);
        }
    }
}
