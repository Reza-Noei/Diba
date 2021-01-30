using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class SuperAdminConfiguration : IEntityTypeConfiguration<SuperAdmin>
    {
        public void Configure(EntityTypeBuilder<SuperAdmin> builder)
        {
            builder.ToTable("SuerAdmins");
            builder.HasMany(P => P.Memberships).WithOne(Q => Q.SuperAdmin).HasForeignKey(Q => Q.SuperAdminId);
            builder.HasOne(P => P.Role).WithOne();
        }
    }
}
