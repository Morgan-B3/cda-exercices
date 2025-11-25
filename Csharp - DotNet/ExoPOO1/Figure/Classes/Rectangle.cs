using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Classes
{
    internal class Rectangle : Figure
    {
        public double Longueur { get; set; }
        public double Largeur { get; set; }

        public Rectangle(double longueur, double largeur, double posX, double posY)
        {
            Largeur = largeur;
            Longueur = longueur;
            Origine = new Point(posX, posY);
        }
    }
}
