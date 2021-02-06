using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Core.Data.Configuration
{
    internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            //builder.HasMany(P => P.SecretaryMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(P => P.SuperAdminMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(P => P.AdminMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(P => P.CollectorMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(P => P.CustomerMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);
            //builder.HasMany(P => P.DeliveryMemberships).WithOne(Q => Q.Organization).HasForeignKey(Q => Q.OrganizationId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(P => P.Creator).WithMany().HasForeignKey(P=>P.CreatorId).IsRequired(false);
            builder.HasOne(P => P.Modifier).WithMany().HasForeignKey(P=>P.ModifierId).IsRequired(false);            
        }
    }
}
