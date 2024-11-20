using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using tgworkshop.domain.models;
using tgworkshop.database.shared;

namespace tgworkshop.database.entityConfig;
public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category), DBConfig.SchemaName);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).HasMaxLength(500).IsRequired();                     
    }
}