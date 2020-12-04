using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Diba.Core.Data.Configuration
{
    internal class SecretaryMembershipConfiguration : IEntityTypeConfiguration<SecretaryMembership>
    {
        public void Configure(EntityTypeBuilder<SecretaryMembership> builder)
        {
            builder.ToTable("SecretaryMemberships");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.HasOne(P => P.Organization).WithMany(Q => Q.SecretaryMemberships).HasForeignKey(P => P.OrganizationId);

            builder.HasOne(P => P.Secretary).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.SecretaryId);
            builder.HasOne(P => P.Authority);
        }
    }
}
