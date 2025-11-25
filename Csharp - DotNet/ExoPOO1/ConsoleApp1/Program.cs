using ExoPOO1.Classes;

Console.WriteLine("---- EXO 2 ----");

Salarie salarie1 = new Salarie();
Salarie salarie2 = new Salarie("456PO", "IT", "B", "Sophie", 1860.35);
Salarie salarie3 = new Salarie("R2D2", "Entretien", "C", "Bob", 350.4);

int choice = -1;
while (choice != 0)
{
    Console.WriteLine("\n");
    Console.WriteLine("=== Gestion de l'entreprise ===");
    Console.WriteLine("1 - Afficher les employés");
    Console.WriteLine("2 - Ajouter un employé");
    Console.WriteLine("3 - Afficher les informations de l'entreprise");
    Console.WriteLine("4 - Renvoyer un employé");
    Console.WriteLine("0 - Quitter");
    Console.WriteLine("Votre choix : ");
    choice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\n");
    switch (choice)
    {
        case 1:
            salarie1.AfficherSalaire();
            salarie2.AfficherSalaire();
            salarie3.AfficherSalaire();
            break;
        case 2:
            int choice2 = -1;
            while(choice2 != 0)
            {
                Console.WriteLine("=== Ajouter un employé ===");
                Console.WriteLine("1 - Salarié");
                Console.WriteLine("2 - Commercial");
                Console.WriteLine("0 - Retour");
                Console.WriteLine("Votre choix : ");
                choice2 = Convert.ToInt32(Console.ReadLine());
                string name;
                string service;
                string matricule;
                switch (choice2)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
            break;
        case 3:
            Salarie.AfficherEntreprise();
            break;
        case 4:
            Salarie.VirerSalarie();
            break;
    }
}