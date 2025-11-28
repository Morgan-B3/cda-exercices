using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.Classes
{
    internal class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Isbn { get; set; }
        public string AnneePublication { get; set; }
        public bool EstDisponible { get; set; }
        public List<Emprunt> Emprunts { get; set; } 

        public Livre() { }
        public Livre(int id, string titre, string auteur, string isbn, string anneePublication, bool estDisponible)
        {
            Id = id;
            Titre = titre;
            Auteur = auteur;
            Isbn = isbn;
            AnneePublication = anneePublication;
            EstDisponible = estDisponible;
        }

        public Livre(string titre, string auteur, string isbn, string anneePublication, bool estDisponible)
        {
            Titre = titre;
            Auteur = auteur;
            Isbn = isbn;
            AnneePublication = anneePublication;
            EstDisponible = estDisponible;
        }
    }
}
