using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(e => e.ShipperId);

            builder.Property(e => e.ShipperId).HasColumnName("shipperid");
            builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Phone).HasColumnName("phone").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Address).HasColumnName("address").HasMaxLength(200);
            builder.Property(e => e.City).HasColumnName("city").HasMaxLength(50);
            builder.Property(e => e.Region).HasColumnName("region").HasMaxLength(50);
            builder.Property(e => e.PostalCode).HasColumnName("postalcode").HasMaxLength(20);
            builder.Property(e => e.Country).HasColumnName("country");
            builder.Property(e => e.CreationDate).HasColumnName("creation_date").IsRequired();
            builder.Property(e => e.CreationUser).HasColumnName("creation_user").IsRequired();
            builder.Property(e => e.ModifyDate).HasColumnName("modify_date");
            builder.Property(e => e.ModifyUser).HasColumnName("modify_user");
            builder.Property(e => e.DeleteDate).HasColumnName("delete_date");
            builder.Property(e => e.DeleteUser).HasColumnName("delete_user");
            builder.Property(e => e.Deleted).HasColumnName("deleted");
        }
    }
}


