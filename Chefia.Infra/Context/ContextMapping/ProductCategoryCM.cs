using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chefia.Infra.Context.ContextMapping;

public class ProductCategoryCM : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(pc => pc.Id);
        builder.Property(pc => pc.Name).IsRequired().HasMaxLength(100);
        builder.Property(pc => pc.Active).IsRequired();

        builder.HasOne(pc => pc.Company)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(pc => pc.Products)
            .WithOne(p => p.ProductCategory)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }

}
