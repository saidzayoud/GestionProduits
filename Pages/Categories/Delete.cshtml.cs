using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Pages.Categories;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteModel(AppDbContext context) => _context = context;

    public Categorie Categorie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null) return NotFound();

        Categorie = categorie;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null) return RedirectToPage("Index");

        if (await _context.Produits.AnyAsync(p => p.CategorieId == id))
        {
            Categorie = categorie;
            ModelState.AddModelError(string.Empty,
                "Impossible de supprimer : cette catégorie contient encore des produits.");
            return Page();
        }

        _context.Categories.Remove(categorie);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}