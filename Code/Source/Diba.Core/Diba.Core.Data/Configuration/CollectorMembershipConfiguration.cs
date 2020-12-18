using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class CollectorMembershipConfiguration : IEntityTypeConfiguration<CollectorMembership>
    {
        public void Configure(EntityTypeBuilder<CollectorMembership> builder)
        {
            builder.ToTable("CollectorMemberships");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.HasOne(P => P.Organization).WithMany(Q => Q.CollectorMemberships).HasForeignKey(P => P.OrganizationId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(P => P.Collector).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.CollectorId);
            builder.HasOne(P => P.Authority);

            builder.HasMany(P => P.Orders).WithOne(Q => Q.CollectorMembership).HasForeignKey(Q => Q.CollectorMembershipId);
        }
    }
}
