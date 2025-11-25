using System;
using System.Collections.Generic;
using System.Text;

namespace ExoPOO1.Classes.Pendu
{
    internal class Pendu
    {
        private StringBuilder _mask;
        private int _tries;
        private Mot _mot;

        public StringBuilder Mask { get { return _mask; } set { _mask = value; } }
        public int Tries { get { return _tries; } set { _tries = value; } }
        public Mot Mot { get { return _mot; } set { _mot = value; } }

        public Pendu() 
        { 
            Mot = new Mot();
            Mask = GenerateMask();
            Tries = 0;
        }

        public void TestChar(string letter)
        {
            Tries++;
            if (letter != null)
            {
                char[] chars = Mot.Word.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    
                    if (chars[i] == letter.ToLower()[0])
                    {
                        Mask[i] = letter[0];
                    }
                }
            }
        }

        public bool TestWin()
        {
            return Mask.ToString() == Mot.Word;
        }

        public StringBuilder GenerateMask()
        {
            StringBuilder mask = new StringBuilder();
            for(int i = 0; i< Mot.Length(); i++)
            {
                mask.Append("*");
            }
            return mask;
        }
    }
}
