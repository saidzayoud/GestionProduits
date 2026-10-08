using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Pages.Produits;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    public EditModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Produit Produit { get; set; } = default!;

    public SelectList Categories { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var produit = await _context.Produits.FindAsync(id);
        if (produit == null) return NotFound();

        Produit = produit;
        await ChargerCategories();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Produit.Categorie");

        if (!ModelState.IsValid)
        {
            await ChargerCategories();
            return Page();
        }

        _context.Attach(Produit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }

    private async Task ChargerCategories()
    {
        var liste = await _context.Categories.OrderBy(c => c.Nom).ToListAsync();
        Categories = new SelectList(liste, "Id", "Nom", Produit?.CategorieId);
    }
}