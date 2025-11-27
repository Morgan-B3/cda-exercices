using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Classes
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse {  get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public List<Commande>? Commandes { get; set; }

        public Client() { }

        public Client(int id, string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
        }

        public Client(string nom, string prenom, string adresse, string codePostal, string ville, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
        }

        public Client(string nom, string prenom, string adresse, string codePostal, string ville, string telephone, List<Commande> commandes)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
            Commandes = commandes;
        }

        public override string ToString()
        {
            return $"{Id} - {Prenom} {Nom} ({Telephone}) - {Adresse} {Ville} {CodePostal}";
        }
    }
}
