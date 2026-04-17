using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chefia.Infra.Context.ContextMapping;

public class TableCM : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable("Tables");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Number).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(200);
        builder.Property(t => t.IsActive).IsRequired();
        builder.Property(t => t.CompanyId).IsRequired();
        builder.Property(t => t.IsOpen).IsRequired();

        builder.HasOne(t => t.Company)
            .WithMany(c => c.Tables)
            .HasForeignKey(t => t.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Orders)
            .WithOne(o => o.Table)
            .HasForeignKey(o => o.TableId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(t => t.Tabs)
            .WithOne(tab => tab.Table)
            .HasForeignKey(tab => tab.TableId)
            .OnDelete(DeleteBehavior.SetNull);
    }

}
