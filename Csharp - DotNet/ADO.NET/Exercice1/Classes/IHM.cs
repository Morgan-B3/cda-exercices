using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice1.Classes
{
    public static class IHM
    {
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== GESTION DES ETUDIANTS =====\n");
                Console.WriteLine("1 - Ajouter un étudiant");
                Console.WriteLine("2 - Afficher tous les étudiants");
                Console.WriteLine("3 - Afficher étudiants par classe");
                Console.WriteLine("4 - Modifier un étudiant");
                Console.WriteLine("5 - Supprimer un étudiant");
                Console.WriteLine("0 - Quitter");
                Console.Write("\nChoix : ");

                string choix = Console.ReadLine();
                Console.Clear();

                switch (choix)
                {
                    case "1": Ajouter(); break;
                    case "2": AfficherTous(); break;
                    case "3": AfficherParClasse(); break;
                    case "4": Modifier(); break;
                    case "5": Supprimer(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Choix non valide.");
                        break;
                }

                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }

        // ------------------------------------------------------------
        // Ajouter
        // ------------------------------------------------------------
        private static void Ajouter()
        {
            Console.WriteLine("=== AJOUT ETUDIANT ===");

            Console.Write("Nom : ");
            string nom = Console.ReadLine();

            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Numéro de classe : ");
            int numeroClasse = int.Parse(Console.ReadLine());
         
            DateTime dateDiplome = AskDate("Date de diplôme (AAAA-MM-JJ) : ");

            var etu = new User
            {
                FirstName = prenom,
                LastName = nom,
                ClassNumber = numeroClasse,
                DateDiploma = dateDiplome
            };

            Console.WriteLine(etu.Save()
                ? "Étudiant ajouté avec succès."
                : "Erreur lors de l’ajout.");
        }

        // ------------------------------------------------------------
        // Afficher tout
        // ------------------------------------------------------------
        private static void AfficherTous()
        {
            Console.WriteLine("=== LISTE DES ETUDIANTS ===");
            
            var list = User.GetAllUsers();

            foreach (var e in list)
            {
                Console.WriteLine($"{e.Id} - {e.FirstName} {e.LastName} | Classe {e.ClassNumber}");
            }
        }

        // ------------------------------------------------------------
        // Afficher par classe
        // ------------------------------------------------------------
        private static void AfficherParClasse()
        {
            Console.Write("Numéro de classe : ");
            int classe = int.Parse(Console.ReadLine());

            var list = User.GetAllUsers(classe);

            Console.WriteLine($"\n=== ETUDIANTS DE LA CLASSE {classe} ===");

            foreach (var e in list)
            {
                Console.WriteLine($"{e.Id} - {e.FirstName} {e.LastName}");
            }
        }

        // ------------------------------------------------------------
        // Modifier
        // ------------------------------------------------------------
        private static void Modifier()
        {
            Console.Write("ID de l'étudiant à modifier : ");
            int id = int.Parse(Console.ReadLine());

            var original = User.GetById(id);

            if (original == null)
            {
                Console.WriteLine("Étudiant introuvable.");
                return;
            }

            Console.WriteLine($"\nModification de : {original.FirstName} {original.LastName}\n");

            Console.Write("Nouveau nom (laisser vide pour conserver) : ");
            string nom = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nom)) original.LastName = nom;

            Console.Write("Nouveau prénom : ");
            string prenom = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(prenom)) original.FirstName = prenom;

            Console.Write("Nouvelle classe : ");
            string classeTxt = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(classeTxt))
                original.ClassNumber = int.Parse(classeTxt);

            Console.Write("Nouvelle date (AAAA-MM-JJ) ou vide pour conserver : ");
            string txtDate = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(txtDate))
                original.DateDiploma = DateTime.Parse(txtDate);

            bool ok = User.EditUser(id, original);

            Console.WriteLine(ok ? "Modification réussie." : "Erreur lors de la modification.");
        }

        // ------------------------------------------------------------
        // Supprimer
        // ------------------------------------------------------------
        private static void Supprimer()
        {
            Console.Write("ID à supprimer : ");
            int id = int.Parse(Console.ReadLine());

            var etu = User.GetById(id);

            if (etu == null)
            {
                Console.WriteLine("Étudiant introuvable.");
                return;
            }

            Console.WriteLine("Supprimer " + etu.FirstName + " " + etu.LastName + " ? (o/n)");
            string rep = Console.ReadLine().ToLower();

            if (rep == "o")
                Console.WriteLine(etu.Delete() ? "Supprimé." : "Erreur.");
        }

        private static DateTime AskDate(string label)
        {
            DateTime date;
            while (true)
            {
                Console.Write(label);
                string txt = Console.ReadLine();

                if (DateTime.TryParse(txt, out date))
                    return date;

                Console.WriteLine("⚠️ Date invalide, recommencez (format : AAAA-MM-JJ).");
            }
        }
    }
}
