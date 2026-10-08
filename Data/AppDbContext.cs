using GestionProduits.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionProduits.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Produit> Produits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seeding de données de test
        modelBuilder.Entity<Categorie>().HasData(
            new Categorie { Id = 1, Nom = "Informatique" },
            new Categorie { Id = 2, Nom = "Bureau" }
        );
    }
}
