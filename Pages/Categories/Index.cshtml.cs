using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    public List<Categorie> Categories { get; set; } = new();

    public async Task OnGetAsync()
    {
        Categories = await _context.Categories
            .Include(c => c.Produits)
            .OrderBy(c => c.Nom)
            .ToListAsync();
    }
}