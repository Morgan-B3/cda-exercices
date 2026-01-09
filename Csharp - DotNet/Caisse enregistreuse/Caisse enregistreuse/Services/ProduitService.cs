using Caisse_enregistreuse.Models;

namespace Caisse_enregistreuse.Services
{
    public class ProduitService
    {
        private static List<Produit> _produits = new();
        private static int _nextId = 1;

        public List<Produit> GetAll() => _produits;

        public Produit? GetById(int id)
            => _produits.FirstOrDefault(p => p.Id == id);

        public void Add(Produit produit)
        {
            produit.Id = _nextId++;
            _produits.Add(produit);
        }

        public void Update(Produit produit)
        {
            var p = GetById(produit.Id);
            if (p == null) return;

            p.Nom = produit.Nom;
            p.Description = produit.Description;
            p.Prix = produit.Prix;
            p.QuantiteStock = produit.QuantiteStock;
            p.CategorieId = produit.CategorieId;
            p.ImagePath = produit.ImagePath;
        }

        public void Delete(int id)
            => _produits.RemoveAll(p => p.Id == id);
    }
}
