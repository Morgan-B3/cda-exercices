using System;
using System.Collections.Generic;
using System.Text;

namespace Pile.Classes
{
    internal class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return ($"{Prenom} {Nom}, {Age} ans");
        }
    }
}
