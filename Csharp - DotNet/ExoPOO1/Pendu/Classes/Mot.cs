using System;
using System.Collections.Generic;
using System.Text;

namespace ExoPOO1.Classes.Pendu
{
    internal class Mot
    {
        private string _word;

        public string Word {  get ; set; }

        public Mot()
        {
            Random random = new Random();
            string[] list = {
                "oreille",
                "citrouille",
                "cadeau",
                "dinosaure",
                "salaire",
                "programmation"
            };
            Word = list[random.Next(list.Length)];
            Console.WriteLine(Word);
        }

        public int Length()
        {
            return Word.Length;
        }
    }
}
