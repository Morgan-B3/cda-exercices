using System;
using System.Collections.Generic;
using System.Text;

namespace ExoPOO1.Classes
{
    internal class Commercial : Salarie
    {
        public double Revenue { get; set; } = 0;
        public double Commission { get; set; } = 0;

        public Commercial(double revenue, double commission, string matricule, string service, string category, string name, double income) : base(matricule,service, category, name, income)
        {
            Revenue = revenue;
            Commission = commission;
        }

        public Commercial() { }

        public new void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {Name} est de {Income+(Revenue*Commission/100)}$");
        }

        public string ToString()
        {
            return $"Le commercial {Name} ({Matricule}) travaille au service {Service} ({Category}). Son salaire est de {Income + (Revenue * Commission / 100)}$.";
        }

    }
}
