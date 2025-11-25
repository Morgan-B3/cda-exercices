using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal class CompteEpargne : CompteBancaire
    {
        public int Id { get; set; }
        public CompteEpargne(Client client)
        {
            base.client = client;
            Id = base.GenerateId();
        }
        public CompteEpargne() : base() { }

        public override string ToString()
        {
            return ($"Le compte épargne n°{Id} contient un solde de {Solde}$");
        }
    }
}
