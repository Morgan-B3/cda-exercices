namespace Caisse_enregistreuse.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }

        public int CategorieId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
