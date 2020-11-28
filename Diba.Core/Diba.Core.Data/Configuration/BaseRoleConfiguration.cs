using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class BaseRoleConfiguration : IEntityTypeConfiguration<BaseRole>
    {
        public void Configure(EntityTypeBuilder<BaseRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.Property(P => P.Title).HasColumnName("Title");

            builder.HasOne(P => P.User).WithMany().HasForeignKey(P=>P.UserId);
        }
    }
}
