using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ExoPOO1.Classes
{
    internal class Salarie
    {
        public string _matricule;
        private string _service;
        private string _category;
        private string _name;
        private double _income;

        private static int _nombreSalaries = 0;
        private static double _totalSalaires = 0;


        public string Matricule { get { return _matricule; } set { _matricule = value; } }
        public string Service { get { return _service; } set { _service = value; } }
        public string Category { get { return _category; } set { _category = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public double Income {
            get { return _income; } 
            set 
            {
                _totalSalaires -= _income;
                _income = value;
                _totalSalaires += _income;
            } 
        }

        public static int NombreSalaries { get {  return _nombreSalaries;} }
        public static double TotalSalaires { get { return _totalSalaires; }  }

        public Salarie()
        {
            Matricule = "123RH";
            Service = "RH";
            Category = "A";
            Name = "Murielle";
            double income = 1750.50;
            Income = income;
            _totalSalaires += income;
            _nombreSalaries++;
        }

        public Salarie(string matricule, string service,  string category, string name, double income)
        {
            Matricule = matricule;
            Service = service;
            Category = category;
            Name = name;
            Income = income;
            _totalSalaires += income;
            _nombreSalaries++;
        }

        public void AfficherSalaire()
        {
            Console.WriteLine($"Le salaire de {Name} est de {Income}$");
        }

        public static void AfficherEntreprise()
        {
            Console.WriteLine($"Le montant total des salaires des {NombreSalaries} employés est de {TotalSalaires}$");
        }

        public static void VirerSalarie()
        {
            if (_nombreSalaries > 0)
            {
                _nombreSalaries--;
                Console.WriteLine("Un employé a été renvoyé");
                Console.WriteLine($"Il y a {_nombreSalaries} salarié(s) dans l'entreprise");
            }
            else
            {
                Console.WriteLine("Il n'y a plus de salariés dans l'entreprise");
            }
        }

        public string ToString()
        {
            return $"Le salarié {Name} ({Matricule}) travaille au service {Service} ({Category}). Son salaire est de {Income}$.";
        }
    }
}
