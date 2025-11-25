using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal class CompteCourant : CompteBancaire
    {
        public int Id { get; set; }
        public CompteCourant(Client client)
        {
            base.client = client;
            Id = GenerateId();
        }
        public CompteCourant() :base() { }

        public override string ToString()
        {
            return($"Le compte courant n°{Id} contient un solde de {Solde}$");
        }
    }
}
