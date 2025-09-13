using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(e => e.CategoryId);

            builder.Property(e => e.CategoryId).HasColumnName("categoryid");
            builder.Property(e => e.CategoryName).HasColumnName("categoryname");
            builder.Property(e => e.Description).HasColumnName("description");
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

