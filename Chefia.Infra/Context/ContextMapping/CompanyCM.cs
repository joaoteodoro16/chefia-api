using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chefia.Infra.Context.ContextMapping;

public class CompanyCM : IEntityTypeConfiguration<Company>
{
       public void Configure(EntityTypeBuilder<Company> builder)
       {
              builder.ToTable("Companies");

              builder.HasKey(x => x.Id);

              builder.Property(x => x.Name)
                     .IsRequired()
                     .HasMaxLength(150);

              builder.Property(x => x.Phone)
                     .HasMaxLength(20);

              builder.Property(x => x.Cnpj)
                     .HasMaxLength(20)
                     .IsRequired();

              builder.HasIndex(x => x.Cnpj).IsUnique();

              builder.HasIndex(x => x.Phone).IsUnique();

              builder.HasMany(x => x.Users)
                     .WithOne(x => x.Company)
                     .HasForeignKey(x => x.CompanyId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(x => x.Products)
                     .WithOne(x => x.Company)
                     .HasForeignKey(x => x.CompanyId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.HasMany(x => x.ProductCategories)
                     .WithOne(x => x.Company)
                     .HasForeignKey(x => x.CompanyId)
                     .OnDelete(DeleteBehavior.Cascade);
       }
}
