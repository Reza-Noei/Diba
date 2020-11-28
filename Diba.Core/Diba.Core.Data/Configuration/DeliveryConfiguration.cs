using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deliveries");
            builder.HasMany(P => P.Memberships).WithOne(Q => Q.Delivery).HasForeignKey(Q => Q.DeliveryId);
            builder.HasOne(P => P.Role).WithOne();
        }
    }
}
