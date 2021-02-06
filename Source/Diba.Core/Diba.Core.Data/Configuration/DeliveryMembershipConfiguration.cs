//using Diba.Core.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Diba.Core.Data.Configuration
//{
//    internal class DeliveryMembershipConfiguration : IEntityTypeConfiguration<DeliveryMembership>
//    {
//        public void Configure(EntityTypeBuilder<DeliveryMembership> builder)
//        {
//            builder.ToTable("DeliveryMemberships");

//            builder.HasKey(P => P.Id);
//            builder.Property(P => P.Id).ValueGeneratedOnAdd();

//            builder.HasOne(P => P.Organization).WithMany(Q => Q.DeliveryMemberships).HasForeignKey(P => P.OrganizationId);

//            builder.HasOne(P => P.Delivery).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.DeliveryId);
//            builder.HasOne(P => P.Authority);

//            builder.HasMany(P => P.Orders).WithOne(Q => Q.DeliveryMembership).HasForeignKey(Q => Q.DeliveryMembershipId);
//        }
//    }
//}
