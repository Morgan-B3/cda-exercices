using ExoPOO1.Classes.Pendu;

Console.WriteLine("---- EXO 3 ----");

Pendu pendu = new Pendu();

int limit = 10;
Console.WriteLine("\n");
Console.WriteLine("=== Jeu du pendu ===");
Console.WriteLine("Vous avez "+limit+" essais. Voulez-vous changer ce nombre ? (Y/N)");
string choice = Console.ReadLine();
if (choice.ToLower() == "y")
{
    Console.WriteLine("\nCombien voulez-vous d'essais ?");
    limit = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("\nPendu généré ! Nombre d'essais : " + limit);
while (pendu.Tries < limit)
{
    Console.WriteLine("Mot à trouver : "+pendu.Mask);
    Console.WriteLine("Saisir une lettre ("+(limit-pendu.Tries)+ " essais restants) :");
    string letter = Console.ReadLine();
    Console.WriteLine("\n");
    pendu.TestChar(letter);
    if (pendu.TestWin())
    {
        Console.WriteLine("Bravo ! le mot était : "+pendu.Mot.Word);
        Console.WriteLine("Vous avez trouvé en "+pendu.Tries+" coups !");
        break;
    }
}

if (pendu.Tries >= limit)
{
    Console.WriteLine("Perdu ! Le mot était : "+pendu.Mot.Word);
}