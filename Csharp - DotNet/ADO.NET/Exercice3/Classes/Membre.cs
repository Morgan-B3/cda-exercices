using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.Classes
{
    internal class Membre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime DateInscription { get; set; }
        public List<Emprunt> Emprunts { get; set; }

        public Membre() { }
        public Membre(int id, string nom, string prenom, string email, DateTime dateInscription, List<Emprunt> emprunts)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateInscription = dateInscription;
            Emprunts = emprunts;
        }

        public Membre(int id, string nom, string prenom, string email, DateTime dateInscription)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateInscription = dateInscription;
        }

        public Membre(string nom, string prenom, string email, DateTime dateInscription)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            DateInscription = dateInscription;
        }
    }
}
