using System.ComponentModel.DataAnnotations;

namespace GestionProduits.Models;

public class Categorie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(50)]
    public string Nom { get; set; } = string.Empty;

    public List<Produit> Produits { get; set; } = new();
}
