using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            //builder.ToTable("Secretaries");
            //builder.HasKey(P => P.Id);
            //builder.Property(P => P.Id).ValueGeneratedOnAdd();

            //builder.HasMany(P => P.Memberships).WithOne(Q => Q.Secretary).HasForeignKey(Q => Q.SecretaryId);
            //builder.HasOne(P => P.Role).WithOne();
        }
    }
}
