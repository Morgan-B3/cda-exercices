using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.Classes
{
    internal class Emprunt
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public int MembreId { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }

        public Emprunt() { }
        public Emprunt(int id, int livreId, int membreId, DateTime dateEmprunt, DateTime dateRetour)
        {
            Id = id;
            LivreId = livreId;
            MembreId = membreId;
            DateEmprunt = dateEmprunt;
            DateRetour = dateRetour;
        }

        public Emprunt(int livreId, int membreId, DateTime dateEmprunt)
        {
            LivreId = livreId;
            MembreId = membreId;
            DateEmprunt = dateEmprunt;
        }

        public Emprunt(int id, int livreId, int membreId, DateTime dateEmprunt)
        {
            Id = id;
            LivreId = livreId;
            MembreId = membreId;
            DateEmprunt = dateEmprunt;
        }

    }
}
