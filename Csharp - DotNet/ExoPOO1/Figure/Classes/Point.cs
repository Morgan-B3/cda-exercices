using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Classes
{
    internal class Point : IDeplacable
    {
        public double PosX { get; set; }
        public double PosY { get; set; }

        public Point(double x, double y) {  PosX = x; PosY = y;}
        public Point() { }

        public override string ToString()
        {
            return ($"Les coordonnées ");
        }

        public void Deplacement(double posX, double posY)
        {
            PosX += posX;
            PosY += posY;
        }
    }
}
