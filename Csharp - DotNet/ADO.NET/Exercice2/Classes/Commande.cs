using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.Classes
{
    internal class Commande
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public Commande() { }
        public Commande(int id, int clientId, DateTime date, decimal total)
        {
            Id = id;
            ClientId = clientId;
            Date = date;
            Total = total;
        }

        public Commande(int clientId, DateTime date, decimal total)
        {
            ClientId = clientId;
            Date = date;
            Total = total;
        }

        public override string ToString()
        {
            return $"N°{Id} - {Date} : {Total}$";
        }
    }
}
