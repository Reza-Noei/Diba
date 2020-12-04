using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class CollectorConfiguration : IEntityTypeConfiguration<Collector>
    {
        public void Configure(EntityTypeBuilder<Collector> builder)
        {
            builder.ToTable("Collectors");

            builder.HasMany(P => P.Memberships).WithOne(Q => Q.Collector).HasForeignKey(Q => Q.CollectorId);
            builder.HasOne(P => P.Role).WithOne();
        }
    }
}
