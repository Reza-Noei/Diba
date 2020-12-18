using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class CustomerOrderConfiguration : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.ToTable("CustomerOrders");

            builder.HasOne(P => P.CollectorMembership).WithMany(Q => Q.Orders).HasForeignKey(P => P.CollectorMembershipId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(P => P.DeliveryMembership).WithMany(Q => Q.Orders).HasForeignKey(P => P.DeliveryMembershipId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(P => P.ServiceType).WithMany().HasForeignKey(P => P.ServiceTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(P => P.Unit).WithMany().HasForeignKey(P => P.UnitId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
