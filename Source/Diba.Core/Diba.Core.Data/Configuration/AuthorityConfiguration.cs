using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class AuthorityConfiguration : IEntityTypeConfiguration<Authority>
    {
        public void Configure(EntityTypeBuilder<Authority> builder)
        {
            builder.ToTable("Authorities");            

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.HasOne(P => P.Creator).WithMany();
            builder.HasOne(P => P.Modifier).WithMany();
        }
    }
}
