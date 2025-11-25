using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal class Client
    {
        public string Id { get; set; } = "123456";
        public string FirstName { get; set; } = "Bob";
        public string LastName { get; set; } = "Doe";
        public string Phone { get; set; } = "01234567";
        public CompteBancaire[] Accounts { get; set; } = [];

        public Client() { }

        public Client(string id, string firstName, string lastName, string phone, CompteBancaire[] accounts)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Accounts = accounts;
        }

        public void ShowAccounts()
        {
            for (int i = 0; i < Accounts.Length; i++)
            {
                Console.WriteLine(Accounts[i].ToString());
            }
        }

        public void CreateAccount(int type)
        {
            if (type >= 1 && type <= 3)
            {
                switch (type)
                {
                    case 1:
                        Accounts = Accounts.Append(new CompteCourant(this)).ToArray();
                        Console.WriteLine($"{Accounts.Length} comptes");
                        break;
                    case 2:
                        Accounts = Accounts.Append(new CompteEpargne(this)).ToArray();
                        break;
                    case 3:
                        Accounts = Accounts.Append(new ComptePayant(this)).ToArray();
                        break;
                }
                Console.WriteLine("Compte créé !");
            }
        }
    }
}
