using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionProduits.Data;
using GestionProduits.Models;

namespace GestionProduits.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produit Produit { get; set; } = new();

        public SelectList Categories { get; set; } = null!;

        public void OnGet()
        {
            Categories = new SelectList(_context.Categories, "Id", "Nom");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Categories = new SelectList(_context.Categories, "Id", "Nom");
                return Page();
            }

            _context.Produits.Add(Produit);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
