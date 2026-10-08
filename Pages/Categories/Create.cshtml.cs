using GestionProduits.Data;
using GestionProduits.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionProduits.Pages.Categories;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    public CreateModel(AppDbContext context) => _context = context;

    [BindProperty]
    public Categorie Categorie { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove("Categorie.Produits");

        if (!ModelState.IsValid) return Page();

        _context.Categories.Add(Categorie);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}