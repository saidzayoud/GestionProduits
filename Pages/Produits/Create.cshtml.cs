using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Pages.Produits;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Produit Produit { get; set; } = new();

    public SelectList Categories { get; set; } = default!;

    public async Task OnGetAsync()
    {
        await ChargerCategories();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Produit.Categorie");

        if (!ModelState.IsValid)
        {
            await ChargerCategories();
            return Page();
        }

        _context.Produits.Add(Produit);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    private async Task ChargerCategories()
    {
        var liste = await _context.Categories.OrderBy(c => c.Nom).ToListAsync();
        Categories = new SelectList(liste, "Id", "Nom");
    }
}