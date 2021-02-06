using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //builder.ToTable("Customers");
            //builder.HasKey(P => P.Id);
            //builder.Property(P => P.Id).ValueGeneratedOnAdd();
            //builder.HasOne(P => P.Organization).WithMany().HasForeignKey(P => P.Organization);

            //builder.HasOne(P => P.Role).WithOne();
            //builder.HasMany(P => P.ContactInfos).WithOne(Q => Q.Customer).HasForeignKey(Q=>Q.CustomerId);
            //builder.HasMany(P => P.Memberships).WithOne(Q => Q.Customer).HasForeignKey(Q => Q.CustomerId);
        }
    }
}