using Microsoft.EntityFrameworkCore;
using tgworkshop.domain.models;

namespace tgworkshop.database;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedCategories();
        builder.SeedProducts();
    }

    private static void SeedCategories(this ModelBuilder builder)
    {
        builder.Entity<Category>(s =>
        {
            s.HasData(new Category
            {
                Id= 1,
                Name= "Teknoloji"
            });

        });
    }

    private static void SeedProducts(this ModelBuilder builder)
    {        
        builder.Entity<Product>(s => 
        {
            s.HasData(new Product
            {
                Id=1,
                Name= "Laptop",
                Price = 1000M,
                Stock = 10,
                CategoryId= 1
            });

        });
    }

}
