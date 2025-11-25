using System;
using System.Collections.Generic;
using System.Text;

namespace Figure.Classes
{
    internal abstract class Figure : IDeplacable
    {
        public Point Origine { get; set; }

        public void Deplacement(double posX, double posY)
        {
            Origine.Deplacement(posX, posY);
        }
    
    }
}
