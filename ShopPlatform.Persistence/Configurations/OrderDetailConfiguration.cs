using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(e => new { e.OrderId, e.ProductId }); 

            builder.Property(e => e.OrderId).HasColumnName("orderid");
            builder.Property(e => e.ProductId).HasColumnName("productid");
            builder.Property(e => e.UnitPrice).HasColumnName("unitprice").HasColumnType("decimal(18,2)");
            builder.Property(e => e.Qty).HasColumnName("qty");
            builder.Property(e => e.Discount).HasColumnName("discount").HasColumnType("decimal(5,2)");

            
            builder.HasOne<Order>()
                   .WithMany()
                   .HasForeignKey(e => e.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

