using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chefia.Infra.Context.ContextMapping;

public class UserCM : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Email).IsRequired().HasMaxLength(254);
        builder.Property(o => o.Password).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Role).IsRequired();
        builder.Property(o => o.CompanyId).IsRequired();
        builder.Property(o => o.Active).IsRequired();


        builder.HasIndex(o => o.Email).IsUnique();
        builder.HasOne(o => o.Company)
               .WithMany(c => c.Users)
               .HasForeignKey(o => o.CompanyId);
    }
}
