using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.EmpId);

            builder.Property(e => e.EmpId).HasColumnName("empid");
            builder.Property(e => e.LastName).HasColumnName("lastname");
            builder.Property(e => e.FirstName).HasColumnName("firstname");
            builder.Property(e => e.Title).HasColumnName("title");
            builder.Property(e => e.TitleOfCourtesy).HasColumnName("titleofcourtesy");
            builder.Property(e => e.BirthDate).HasColumnName("birthdate");
            builder.Property(e => e.HireDate).HasColumnName("hiredate");
            builder.Property(e => e.Address).HasColumnName("address");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.Region).HasColumnName("region");
            builder.Property(e => e.PostalCode).HasColumnName("postalcode");
            builder.Property(e => e.Country).HasColumnName("country");
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.MgrId).HasColumnName("mgrid");
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
