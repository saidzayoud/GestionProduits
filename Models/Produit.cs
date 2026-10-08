using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProduits.Models;

public class Produit
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(100)]
    public string Nom { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 1000000, ErrorMessage = "Prix invalide")]
    public decimal Prix { get; set; }

    [Display(Name = "Catégorie")]
    public int CategorieId { get; set; }

    public Categorie? Categorie { get; set; }

    [Display(Name = "Stock")]
    [NotMapped]
    [Range(0, int.MaxValue, ErrorMessage = "Stock invalide")]
    public int Stock { get; set; } = 0;
}
