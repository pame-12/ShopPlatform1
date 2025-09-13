using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(e => e.OrderId);

            builder.Property(e => e.OrderId).HasColumnName("orderid");
            builder.Property(e => e.CustId).HasColumnName("custid");
            builder.Property(e => e.EmpId).HasColumnName("empid");
            builder.Property(e => e.OrderDate).HasColumnName("orderdate");
            builder.Property(e => e.RequiredDate).HasColumnName("requireddate");
            builder.Property(e => e.ShippedDate).HasColumnName("shippeddate");
            builder.Property(e => e.ShipperId).HasColumnName("shipperid");
            builder.Property(e => e.Freight).HasColumnName("freight").HasColumnType("decimal(18,2)");
            builder.Property(e => e.ShipName).HasColumnName("shipname").HasMaxLength(100);
            builder.Property(e => e.ShipAddress).HasColumnName("shipaddress").HasMaxLength(200);
            builder.Property(e => e.ShipCity).HasColumnName("shipcity").HasMaxLength(50);
            builder.Property(e => e.ShipRegion).HasColumnName("shipregion").HasMaxLength(50);
            builder.Property(e => e.ShipPostalCode).HasColumnName("shippostalcode").HasMaxLength(20);
            builder.Property(e => e.ShipCountry).HasColumnName("shipcountry").HasMaxLength(50);
        }
    }
}

