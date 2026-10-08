using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Pages.Produits;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    public List<Produit> Produits { get; set; } = new();

    public async Task OnGetAsync()
    {
        Produits = await _context.Produits
            .Include(p => p.Categorie)
            .OrderBy(p => p.Nom)
            .ToListAsync();
    }
}
