using Exercice3.DAO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.Classes
{
    internal class IHM
    {
        static LivreDAO livreDao = new LivreDAO();
        static MembreDAO membreDao = new MembreDAO();
        static EmpruntDAO empruntDao = new EmpruntDAO();

        public void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
========= MENU BIBLIOTHÈQUE =========
1. Gestion des livres
2. Gestion des membres
3. Gestion des emprunts
0. Quitter
=====================================
");
                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": MenuLivres(); break;
                    case "2": MenuMembres(); break;
                    case "3": MenuEmprunts(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Choix invalide !"); Console.ReadKey(); break;
                }
            }
        }

        // -----------------------------
        // MENU LIVRES
        // -----------------------------
        static void MenuLivres()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
======= GESTION DES LIVRES =======
1. Ajouter un livre
2. Lister les livres
3. Rechercher par auteur
0. Retour
");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": AjouterLivre(); break;
                    case "2": ListerLivres(); break;
                    case "3": RechercherLivreAuteur(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Choix invalide !"); Console.ReadKey(); break;
                }
            }
        }

        static void AjouterLivre()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter un livre ===");

            Livre l = new Livre();
            Console.Write("Titre : "); l.Titre = Console.ReadLine();
            Console.Write("Auteur : "); l.Auteur = Console.ReadLine();
            Console.Write("ISBN : "); l.Isbn = Console.ReadLine();
            Console.Write("Année de publication : "); l.AnneePublication = Console.ReadLine();
            l.EstDisponible = true;

            livreDao.Save(l);
            Console.WriteLine("✔ Livre ajouté !");
            Console.ReadKey();
        }

        static void ListerLivres()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des livres ===");

            foreach (var l in livreDao.GetAll())
            {
                Console.WriteLine($"{l.Id} - {l.Titre} ({l.Auteur}) - Disponible : {l.EstDisponible}");
            }

            Console.ReadKey();
        }

        static void RechercherLivreAuteur()
        {
            Console.Clear();
            Console.Write("Auteur : ");
            string auteur = Console.ReadLine();

            List<Livre> ? livres = livreDao.GetByAuteur(auteur);

            Console.WriteLine($"=== Livres de {auteur} ===");

            foreach (var l in livres)
                Console.WriteLine($"{l.Id} - {l.Titre}");

            Console.ReadKey();
        }

        // -----------------------------
        // MENU MEMBRES
        // -----------------------------
        static void MenuMembres()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
======= GESTION DES MEMBRES =======
1. Ajouter un membre
2. Lister les membres
3. Rechercher par email
0. Retour
");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": AjouterMembre(); break;
                    case "2": ListerMembres(); break;
                    case "3": RechercherMembreEmail(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Choix invalide !"); Console.ReadKey(); break;
                }
            }
        }

        static void AjouterMembre()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter un membre ===");

            Membre m = new Membre();
            Console.Write("Nom : "); m.Nom = Console.ReadLine();
            Console.Write("Prénom : "); m.Prenom = Console.ReadLine();
            Console.Write("Email : "); m.Email = Console.ReadLine();
            m.DateInscription = DateTime.Now;

            membreDao.Save(m);
            Console.WriteLine("✔ Membre ajouté !");
            Console.ReadKey();
        }

        static void ListerMembres()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des membres ===");

            foreach (var m in membreDao.GetAll())
            {
                Console.WriteLine($"{m.Id} - {m.Prenom} {m.Nom} ({m.Email})");
            }

            Console.ReadKey();
        }

        static void RechercherMembreEmail()
        {
            Console.Clear();
            Console.Write("Email : ");
            string email = Console.ReadLine();

            List<Membre> membres = membreDao.GetByEmail(email);

            if (membres.IsNullOrEmpty())
                Console.WriteLine("❌ Aucun membre trouvé !");
            else
            {
                foreach(var m in membres)
                Console.WriteLine($"{m.Id} - {m.Email} - {m.Prenom} {m.Nom}");
            }

            Console.ReadKey();
        }

        // -----------------------------
        // MENU EMPRUNTS
        // -----------------------------
        static void MenuEmprunts()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
======= GESTION DES EMPRUNTS =======
1. Emprunter un livre
2. Retourner un livre
3. Voir les emprunts en cours
0. Retour
");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": EmprunterLivre(); break;
                    case "2": RetournerLivre(); break;
                    case "3": VoirEmprunts(); break;
                    case "0": return;
                    default: Console.WriteLine("❌ Choix invalide !"); Console.ReadKey(); break;
                }
            }
        }

        static void EmprunterLivre()
        {
            Console.Clear();
            Console.WriteLine("=== Emprunter un livre ===");

            Console.Write("ID Livre : ");
            int idLivre = int.Parse(Console.ReadLine());

            Console.Write("ID Membre : ");
            int idMembre = int.Parse(Console.ReadLine());

            Emprunt emprunt = new Emprunt(idLivre, idMembre, DateTime.Now);

            empruntDao.Save(emprunt);

            Console.WriteLine("✔ Emprunt enregistré !");
            Console.ReadKey();
        }

        static void RetournerLivre()
        {
            Console.Clear();
            Console.WriteLine("=== Retourner un livre ===");

            Console.Write("ID Emprunt : ");
            int id = int.Parse(Console.ReadLine());

            bool isOk =  empruntDao.Retourner(id);

            if (isOk)
            {
                Console.WriteLine("✔ Livre retourné !");
            } else
            {
                Console.WriteLine("Erreur");
            }

            Console.ReadKey();
        }

        static void VoirEmprunts()
        {
            Console.Clear();
            Console.WriteLine("=== Emprunts en cours ===");

            foreach (var e in empruntDao.GetEnCours())
            {
                Console.WriteLine($"Emprunt {e.Id} : Livre {e.LivreId} par Membre {e.MembreId} le {e.DateEmprunt}");
            }

            Console.ReadKey();
        }
    }
}
