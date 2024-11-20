using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using tgworkshop.database.shared;
using tgworkshop.domain.models;

namespace tgworkshop.database.entityConfig;
public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), DBConfig.SchemaName);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).HasMaxLength(500).IsRequired();

        builder.HasOne(s => s.Category).WithMany(s => s.Products).HasForeignKey(s => s.CategoryId);
    }
}