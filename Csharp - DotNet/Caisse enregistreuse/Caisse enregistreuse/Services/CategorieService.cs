using Caisse_enregistreuse.Models;

namespace Caisse_enregistreuse.Services
{
    public class CategorieService
    {
        private static List<Categorie> _categories = new();
        private static int _nextId = 1;

        public List<Categorie> GetAll() => _categories;

        public Categorie? GetById(int id)
            => _categories.FirstOrDefault(p => p.Id == id);

        public void Add(Categorie categorie)
        {
            categorie.Id = _nextId++;
            _categories.Add(categorie);
        }

        public void Update(Categorie categorie)
        {
            var c = GetById(categorie.Id);
            if (c == null) return;

            c.Nom = categorie.Nom;
            c.Produits = categorie.Produits;
        }

        public void Delete(int id)
            => _categories.RemoveAll(p => p.Id == id);
    }
}
