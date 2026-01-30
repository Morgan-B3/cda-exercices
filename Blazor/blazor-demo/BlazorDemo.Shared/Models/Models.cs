using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 99999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        public string Category { get; set; } = "";

        [Range(0, 10000)]
        public int Stock { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    public class ProductDto
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 99999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        public string Category { get; set; } = "";

        [Range(0, 10000)]
        public int Stock { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
