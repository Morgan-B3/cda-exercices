using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal class ComptePayant : CompteBancaire
    {
        public int Id { get; set; }
        public ComptePayant(Client client)
        {
            base.client = client;
            Id = base.GenerateId();
        }
        public ComptePayant() : base() { }

        public override string ToString()
        {
            return ($"Le compte payant n°{Id} contient un solde de {Solde}$");
        }
    }
}
