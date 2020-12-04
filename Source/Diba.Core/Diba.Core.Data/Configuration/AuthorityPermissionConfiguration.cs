using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class AuthorityPermissionConfiguration : IEntityTypeConfiguration<AuthorityPermission>
    {
        public void Configure(EntityTypeBuilder<AuthorityPermission> builder)
        {
            builder.ToTable("AuthorityPermissions");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.HasOne(P => P.Authority).WithMany(Q=>Q.Permissions).HasForeignKey(P=>P.AuthorityId);
        }
    }
}
