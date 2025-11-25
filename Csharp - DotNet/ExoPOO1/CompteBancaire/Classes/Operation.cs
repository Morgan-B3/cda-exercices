using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    internal class Operation
    {
        private static int Number { get; set; } = 0;
        public decimal Amount { get; set; }
        public string Status { get; set; }

        public Operation() { }

        public Operation(decimal amount, string status)
        {
            Number = GenerateNumber();
            Amount = amount;
            Status = status;
        }

        private int GenerateNumber()
        {
            Number++;
            return Number;
        }

        public override string ToString()
        {
            string type = Status == "Retrait" ? "-" : "+";
            return ($"Opération n°{Number} - {Status} : {type}{Amount}$");
        }
    }
}
