using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.State).HasConversion(new OrderStateValueConverter());

            builder.HasOne(o => o.Customer).WithMany(p => p.Orders);

            builder.OwnsMany(a => a.OrderItems, map =>
            {
                map.ToTable("OrderItems").HasKey("Id");
                map.Property<long>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("OrderId");

                map.Property(a => a.ServiceId);
                map.Property(a => a.UnitPrice);
                map.Property(a => a.Units);
                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.OwnsOne(a => a.Request).Property(p => p.Items);
            builder.OwnsOne(a => a.Request).Property(p => p.AnnouncedPrice);

            builder.OwnsOne(a => a.CollectionInfo).Property(p => p.CollectorId);
            builder.OwnsOne(a => a.CollectionInfo).Property(p => p.CollectionDate);
            builder.OwnsOne(a => a.CollectionInfo).Property(p => p.CollectionLocation);

            builder.OwnsOne(a => a.DeliveryInfo).Property(p => p.DelivelerId);
            builder.OwnsOne(a => a.DeliveryInfo).Property(p => p.DeliveryDate);
            builder.OwnsOne(a => a.DeliveryInfo).Property(p => p.DeliveryLocation);

        }
    }
}