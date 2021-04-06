using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(P => P.Organization).WithMany(Q => Q.Customers).HasForeignKey(P => P.OrganizationId);
            builder.HasMany(p => p.Orders).WithOne(p => p.Customer);
        }
    }
}