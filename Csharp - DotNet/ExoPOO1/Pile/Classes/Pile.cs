using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Pile.Classes
{
    internal class Pile<T>
    {
        private T[] _elements = new T[0];
        public T[] Elements => _elements;
        public int Count => _elements.Length;

        public void Empiler(T element)
        {
            Array.Resize(ref _elements, _elements.Length + 1);
            _elements[^1] = element;
        }

        public T Depiler()
        {
            if (_elements.Length == 0)
            {
                throw new InvalidOperationException("La pile est vide.");
            }

            T valeur = _elements[^1];
            Array.Resize(ref _elements, _elements.Length - 1);
            return valeur;
        }

        public T RetirerParIndex(int index)
        {
            if (index < 0 || index >= _elements.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            T valeur = _elements[index];

            T[] nouveau = new T[_elements.Length - 1];

            for (int i = 0, j = 0; i < _elements.Length; i++)
            {
                if (i != index)
                {
                    nouveau[j++] = _elements[i];
                }
            }

            _elements = nouveau;

            return valeur;
        }

        public void Afficher()
        {
            Console.WriteLine("Contenu de la pile :");
            for (int i = _elements.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"[{i}] {_elements[i]}");
            }
        }

    }
}
