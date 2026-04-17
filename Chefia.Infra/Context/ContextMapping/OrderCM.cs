using Chefia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chefia.Infra.Context.ContextMapping;

public class OrderCM : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CompanyId).IsRequired();
        builder.Property(o => o.TableId).IsRequired(false);
        builder.Property(o => o.TabId).IsRequired(false);
        builder.Property(o => o.OrderNumber).IsRequired();
        builder.Property(o => o.Description).HasMaxLength(200);
        builder.Property(o => o.Price).HasColumnType("decimal(10,2)").IsRequired();

        builder.HasOne(o => o.Company)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}

