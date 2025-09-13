using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.ProductId).HasColumnName("productid");
            builder.Property(e => e.ProductName).HasColumnName("productname");
            builder.Property(e => e.SupplierId).HasColumnName("supplierid");
            builder.Property(e => e.CategoryId).HasColumnName("categoryid");
            builder.Property(e => e.UnitPrice).HasColumnName("unitprice");
            builder.Property(e => e.Discontinued).HasColumnName("discontinued");
            builder.Property(e => e.CreationDate).HasColumnName("creation_date");
            builder.Property(e => e.CreationUser).HasColumnName("creation_user");
            builder.Property(e => e.ModifyDate).HasColumnName("modify_date");
            builder.Property(e => e.ModifyUser).HasColumnName("modify_user");
            builder.Property(e => e.DeleteUser).HasColumnName("delete_user");
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date");
            builder.Property(e => e.Deleted).HasColumnName("deleted");
        }
    }
}

