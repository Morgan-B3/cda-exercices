using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Classes
{
    using Exercice2.DAO;
    using System;

    internal class IHM
    {
        static ClientDAO clientDAO = new ClientDAO();
        static CommandeDAO commandeDAO = new CommandeDAO();
        public void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("   ____                                          _           ");
                Console.WriteLine("  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | ___  ___ ");
                Console.WriteLine(" | |   / _ \\| '_ ` _ \\| '_ ` _ \\ / _` | '_ \\ / _` |/ _ \\/ __|");
                Console.WriteLine(" | |__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/\\__ \\");
                Console.WriteLine("  \\____\\___/|_| |_| |_|_| |_| |_|\\__,_|_| |_|\\__,_|\\___||___/");
                Console.WriteLine();
                Console.WriteLine("1. Afficher les clients");
                Console.WriteLine("2. Créer un client");
                Console.WriteLine("3. Modifier un client");
                Console.WriteLine("4. Supprimer un client");
                Console.WriteLine("5. Afficher les détails d'un client");
                Console.WriteLine("6. Ajouter une commande");
                Console.WriteLine("7. Modifier une commande");
                Console.WriteLine("8. Supprimer une commande");
                Console.WriteLine("0. Quitter");
                Console.WriteLine();
                Console.Write("Votre choix : ");

                string choix = Console.ReadLine();
                Console.Clear();

                switch (choix)
                {
                    case "1": AfficherClients(); break;
                    case "2": CreerClient(); break;
                    case "3": ModifierClient(); break;
                    case "4": SupprimerClient(); break;
                    case "5": AfficherDetailsClient(); break;
                    case "6": AjouterCommande(); break;
                    case "7": ModifierCommande(); break;
                    case "8": SupprimerCommande(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }

                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }

        // ───────────────────────────────────────────────
        // 1. Afficher tous les clients
        // ───────────────────────────────────────────────
        static void AfficherClients()
        {
            List<Client> clients = clientDAO.GetAll();

            Console.WriteLine("LISTE DES CLIENTS :\n");

            foreach (var c in clients)
                Console.WriteLine($"{c.Id} - {c.Prenom} {c.Nom} ({c.Ville})");
        }

        // ───────────────────────────────────────────────
        // 2. Créer un client
        // ───────────────────────────────────────────────
        static void CreerClient()
        {
            Console.WriteLine("CRÉATION D’UN CLIENT :\n");

            Client c = new Client();

            Console.Write("Nom : "); c.Nom = Console.ReadLine();
            Console.Write("Prénom : "); c.Prenom = Console.ReadLine();
            Console.Write("Adresse : "); c.Adresse = Console.ReadLine();
            Console.Write("Code Postal : "); c.CodePostal = Console.ReadLine();
            Console.Write("Ville : "); c.Ville = Console.ReadLine();
            Console.Write("Téléphone : "); c.Telephone = Console.ReadLine();

            Console.WriteLine(clientDAO.Save(c));
        }

        // ───────────────────────────────────────────────
        // 3. Modifier un client
        // ───────────────────────────────────────────────
        static void ModifierClient()
        {
            Console.Write("ID du client à modifier : ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            Client c = clientDAO.getOneById(id);
            if (c == null)
            {
                Console.WriteLine("Client introuvable.");
                return;
            }

            Console.WriteLine("\nLaissez vide pour ne pas modifier.");

            Console.Write($"Nom ({c.Nom}) : "); string v = Console.ReadLine(); if (v != "") c.Nom = v;
            Console.Write($"Prénom ({c.Prenom}) : "); v = Console.ReadLine(); if (v != "") c.Prenom = v;
            Console.Write($"Adresse ({c.Adresse}) : "); v = Console.ReadLine(); if (v != "") c.Adresse = v;
            Console.Write($"Code Postal ({c.CodePostal}) : "); v = Console.ReadLine(); if (v != "") c.CodePostal = v;
            Console.Write($"Ville ({c.Ville}) : "); v = Console.ReadLine(); if (v != "") c.Ville = v;
            Console.Write($"Téléphone ({c.Telephone}) : "); v = Console.ReadLine(); if (v != "") c.Telephone = v;

            if (clientDAO.Update(c))
                Console.WriteLine("\n✔ Client mis à jour !");
            else
                Console.WriteLine("\n❌ Erreur lors de la mise à jour.");
        }

        // ───────────────────────────────────────────────
        // 4. Supprimer un client
        // ───────────────────────────────────────────────
        static void SupprimerClient()
        {
            Console.Write("ID du client à supprimer : ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (clientDAO.DeleteById(id))
                Console.WriteLine("\n✔ Client (et commandes) supprimés !");
            else
                Console.WriteLine("\n❌ Erreur lors de la suppression.");
        }

        // ───────────────────────────────────────────────
        // 5. Afficher détail client + commandes
        // ───────────────────────────────────────────────
        static void AfficherDetailsClient()
        {
            Console.Write("ID du client : ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var client = clientDAO.getOneById(id);
            if (client == null)
            {
                Console.WriteLine("Client introuvable.");
                return;
            }

            Console.WriteLine($"\n{client.Prenom} {client.Nom}");
            Console.WriteLine($"{client.Adresse}, {client.CodePostal} {client.Ville}");
            Console.WriteLine($"Téléphone : {client.Telephone}\n");

            var commandes = client.Commandes;

            if (commandes.Count == 0)
            {
                Console.WriteLine("Aucune commande.");
                return;
            }

            Console.WriteLine("COMMANDES :");
            foreach (var cmd in commandes)
                Console.WriteLine($"{cmd.Id} - {cmd.Date.ToShortDateString()} - {cmd.Total} €");
        }

        // ───────────────────────────────────────────────
        // 6. Ajouter une commande
        // ───────────────────────────────────────────────
        static void AjouterCommande()
        {
            Console.Write("ID du client : ");
            if (!int.TryParse(Console.ReadLine(), out int idClient)) return;

            if (clientDAO.getOneById(idClient) == null)
            {
                Console.WriteLine("Client introuvable.");
                return;
            }

            Commande cmd = new Commande();
            cmd.ClientId = idClient;

            cmd.Date = DateTime.Now;

            Console.Write("Total : ");
            cmd.Total = decimal.Parse(Console.ReadLine());

            Console.WriteLine(commandeDAO.Save(cmd));
        }

        // ───────────────────────────────────────────────
        // 7. Modifier une commande
        // ───────────────────────────────────────────────
        static void ModifierCommande()
        {
            Console.Write("ID de la commande : ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var cmd = commandeDAO.getOneById(id);
            if (cmd == null)
            {
                Console.WriteLine("Commande introuvable.");
                return;
            }

            Console.WriteLine("\nLaissez vide pour ne pas modifier.");

            Console.Write($"Date ({cmd.Date:yyyy-MM-dd}) : ");
            string v = Console.ReadLine();
            if (v != "")
                cmd.Date = DateTime.Parse(v);

            Console.Write($"Total ({cmd.Total}) : ");
            v = Console.ReadLine();
            if (v != "")
                cmd.Total = decimal.Parse(v);

            if (commandeDAO.Update(cmd))
                Console.WriteLine("\n✔ Commande modifiée !");
            else
                Console.WriteLine("\n❌ Erreur lors de la modification.");
        }

        // ───────────────────────────────────────────────
        // 8. Supprimer une commande
        // ───────────────────────────────────────────────
        static void SupprimerCommande()
        {
            Console.Write("ID de la commande : ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            if (commandeDAO.DeleteById(id))
                Console.WriteLine("\n✔ Commande supprimée !");
            else
                Console.WriteLine("\n❌ Erreur lors de la suppression.");
        }
    }

}
