using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal abstract class CompteBancaire
    {
        protected decimal Solde { get; set; } = decimal.Zero;
        protected Client client;
        protected Operation[] Operations { get; set; } = [];
        protected int Id { get; set; } = 0;

        protected int GenerateId()
        {
            Id++;
            return Id;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Solde) 
            {
                Operations = Operations.Append(new Operation(amount, "Retrait")).ToArray();
                Solde -= amount;
                Console.WriteLine($"{amount}$ retirés. Nouveau solde : {Solde}$");
            } 
            else
            {
                Console.WriteLine($"Solde insuffisant ! ({Solde}$)");
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Operations = Operations.Append(new Operation(amount, "Dépôt")).ToArray();
                Solde += amount;
                Console.WriteLine($"{amount}$ déposés. Nouveau solde : {Solde}$");
            }
        }

        public void ShowOperations()
        {
            for (int i = 0; i < Operations.Length; i++)
            {
                Console.WriteLine(Operations[i].ToString());
            }
        }
    }
}
