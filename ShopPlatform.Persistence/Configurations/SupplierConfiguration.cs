using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(e => e.SupplierId);

            builder.Property(e => e.SupplierId).HasColumnName("supplierid");
            builder.Property(e => e.CompanyName).HasColumnName("companyname");
            builder.Property(e => e.ContactName).HasColumnName("contactname");
            builder.Property(e => e.ContactTitle).HasColumnName("contacttitle");
            builder.Property(e => e.Address).HasColumnName("address");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.Region).HasColumnName("region");
            builder.Property(e => e.PostalCode).HasColumnName("postalcode");
            builder.Property(e => e.Country).HasColumnName("country");
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.Fax).HasColumnName("fax");
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

