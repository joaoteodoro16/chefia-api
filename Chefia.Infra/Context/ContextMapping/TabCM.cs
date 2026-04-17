using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chefia.Infra.Context.ContextMapping;

public class TabCM : IEntityTypeConfiguration<Tab>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tab> builder)
    {
        builder.ToTable("Tabs");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Number).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(200);
        builder.Property(t => t.IsActive).IsRequired();
        builder.Property(t => t.CompanyId).IsRequired();
        builder.Property(t => t.TableId).IsRequired();
        builder.Property(t => t.IsOpen).IsRequired();

        builder.HasOne(t => t.Company)
            .WithMany(c => c.Tabs)
            .HasForeignKey(t => t.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Table)
            .WithMany(tab => tab.Tabs)
            .HasForeignKey(t => t.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(t => t.Orders)
            .WithOne(o => o.Tab)
            .HasForeignKey(o => o.TabId)
            .OnDelete(DeleteBehavior.SetNull);
    }

}
