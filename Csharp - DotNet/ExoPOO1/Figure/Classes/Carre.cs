using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Figure.Classes
{
    internal class Carre : Figure
    {
        public double Cote { get; set; }
        public Carre(double cote, double posX, double posY) 
        {  
            Cote = cote;
            Origine = new Point(posX, posY);
        }
        public Carre() { }
    }
}
