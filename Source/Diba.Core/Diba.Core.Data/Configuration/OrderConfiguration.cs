using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();
            builder.HasMany(P => P.RequestItems).WithOne(x=>x.Order).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Customer).WithMany(p => p.Orders);
        }
    }

    public class RequestItemConfiguration : IEntityTypeConfiguration<RequestItem>
    {
        public void Configure(EntityTypeBuilder<RequestItem> builder)
        {
            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Order).WithMany(x=>x.RequestItems);
        }
    }
}