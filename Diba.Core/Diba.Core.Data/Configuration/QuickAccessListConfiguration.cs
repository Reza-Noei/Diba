using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class QuickAccessListConfiguration : IEntityTypeConfiguration<QuickAccessList>
    {
        public void Configure(EntityTypeBuilder<QuickAccessList> builder)
        {
            builder.ToTable("QuickAccessLists");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();

            builder.HasMany(P => P.Items).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
