using Microsoft.EntityFrameworkCore;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Data;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("DataSource=products.db;Cache=Shared");

    
}
