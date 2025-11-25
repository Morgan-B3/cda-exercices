using System;
using System.Collections.Generic;
using System.Text;

namespace Pile.Classes
{
    internal class IHM
    {
        public void Main()
        {
            Pile<string> pileString = new Pile<string>();
            Pile<decimal> pileDecimal = new Pile<decimal>();
            Pile<Personne> pilePersonnes = new Pile<Personne>();

            int choix;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Pile de STRING");
                Console.WriteLine("2 - Pile de DECIMAL");
                Console.WriteLine("3 - Pile de PERSONNE");
                Console.WriteLine("0 - Quitter");
                Console.Write("Votre choix : ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1: MenuTemplate(pileString, MenuString); break;
                    case 2: MenuTemplate(pileDecimal, MenuDecimal); break;
                    case 3: MenuTemplate(pilePersonnes, MenuPersonne); break;
                }

            } while (choix != 0);
        }

        static void MenuTemplate<T>(Pile<T> pile, Func<T> saisieElement, Action<T>? affiche = null)
        {
            affiche ??= (e => Console.WriteLine(e));

            int choix;

            do
            {
                Console.Clear();
                Console.WriteLine($"=== PILE DE {typeof(T).Name.ToUpper()} ===");
                Console.WriteLine("1 - Empiler");
                Console.WriteLine("2 - Dépiler");
                Console.WriteLine("3 - Supprimer par index");
                Console.WriteLine("4 - Afficher");
                Console.WriteLine("0 - Retour");
                Console.Write("Choix : ");

                if (!int.TryParse(Console.ReadLine(), out choix))
                    choix = -1;

                switch (choix)
                {
                    case 1:
                        // Empiler
                        T element = saisieElement();
                        pile.Empiler(element);
                        break;

                    case 2:
                        // Dépiler
                        if (pile.Count == 0)
                            Console.WriteLine("Pile vide !");
                        else
                            Console.WriteLine("Dépilé : " + pile.Depiler());
                        Console.ReadKey();
                        break;

                    case 3:
                        // Supprimer par index
                        try
                        {
                            Console.Write("Index : ");
                            int index = int.Parse(Console.ReadLine());
                            Console.WriteLine("Supprimé : " + pile.RetirerParIndex(index));
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("❌ Erreur : l'index est invalide !");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erreur inattendue : " + ex.Message);
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        // Afficher
                        Console.WriteLine("Contenu de la pile :");
                        foreach (var e in pile.Elements.Reverse())
                            affiche(e);
                        Console.ReadKey();
                        break;
                }

            } while (choix != 0);
        }


        static string MenuString()
        {
            Console.Write("Entrez une chaîne : ");
            return Console.ReadLine();
        }

        static decimal MenuDecimal()
        {
            Console.Write("Entrez un nombre : ");
            decimal.TryParse(Console.ReadLine(), out decimal d);
            return d;
        }

        static Personne MenuPersonne()
        {
            Personne p = new Personne();

            Console.Write("Nom : ");
            p.Nom = Console.ReadLine();

            Console.Write("Prénom : ");
            p.Prenom = Console.ReadLine();

            Console.Write("Âge : ");
            int.TryParse(Console.ReadLine(), out int age);
            p.Age = age;

            return p;
        }


        static void IHMString(Pile<string> pile)
        {
            int choix;

            do
            {
                Console.Clear();
                Console.WriteLine("=== PILE STRING ===");
                Console.WriteLine("1 - Empiler");
                Console.WriteLine("2 - Dépiler");
                Console.WriteLine("3 - Supprimer par index");
                Console.WriteLine("4 - Afficher");
                Console.WriteLine("0 - Retour");
                Console.Write("Choix : ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Console.Write("Entrez un texte : ");
                        pile.Empiler(Console.ReadLine());
                        break;

                    case 2:
                        Console.WriteLine("Dépilé : " + pile.Depiler());
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Index à supprimer : ");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Supprimé : " + pile.RetirerParIndex(index));
                        Console.ReadKey();
                        break;

                    case 4:
                        pile.Afficher();
                        Console.ReadKey();
                        break;
                }

            } while (choix != 0);
        }

        static void IHMDecimal(Pile<decimal> pile)
        {
            int choix;

            do
            {
                Console.Clear();
                Console.WriteLine("=== PILE DECIMAL ===");
                Console.WriteLine("1 - Empiler");
                Console.WriteLine("2 - Dépiler");
                Console.WriteLine("3 - Supprimer par index");
                Console.WriteLine("4 - Afficher");
                Console.WriteLine("0 - Retour");
                Console.Write("Choix : ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Console.Write("Entrez un nombre : ");
                        pile.Empiler(decimal.Parse(Console.ReadLine()));
                        break;

                    case 2:
                        Console.WriteLine("Dépilé : " + pile.Depiler());
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Index : ");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Supprimé : " + pile.RetirerParIndex(index));
                        Console.ReadKey();
                        break;

                    case 4:
                        pile.Afficher();
                        Console.ReadKey();
                        break;
                }

            } while (choix != 0);
        }

        static void IHMPersonne(Pile<Personne> pile)
        {
            int choix;

            do
            {
                Console.Clear();
                Console.WriteLine("=== PILE PERSONNE ===");
                Console.WriteLine("1 - Empiler une personne");
                Console.WriteLine("2 - Dépiler");
                Console.WriteLine("3 - Supprimer par index");
                Console.WriteLine("4 - Afficher");
                Console.WriteLine("0 - Retour");
                Console.Write("Choix : ");
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Personne p = new Personne();
                        Console.Write("Nom : "); p.Nom = Console.ReadLine();
                        Console.Write("Prénom : "); p.Prenom = Console.ReadLine();
                        Console.Write("Âge : "); p.Age = int.Parse(Console.ReadLine());
                        pile.Empiler(p);
                        break;

                    case 2:
                        Console.WriteLine("Dépilé : " + pile.Depiler());
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Index : ");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Supprimé : " + pile.RetirerParIndex(index));
                        Console.ReadKey();
                        break;

                    case 4:
                        pile.Afficher();
                        Console.ReadKey();
                        break;
                }

            } while (choix != 0);
        }
    }
}
