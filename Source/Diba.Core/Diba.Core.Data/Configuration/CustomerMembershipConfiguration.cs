//using Diba.Core.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Diba.Core.Data.Configuration
//{
//    internal class CustomerMembershipConfiguration : IEntityTypeConfiguration<CustomerMembership>
//    {
//        public void Configure(EntityTypeBuilder<CustomerMembership> builder)
//        {
//            builder.ToTable("CustomerMemberships");

//            builder.HasKey(P => P.Id);
//            builder.Property(P => P.Id).ValueGeneratedOnAdd();

//            builder.HasOne(P => P.Organization).WithMany(Q => Q.CustomerMemberships).HasForeignKey(P => P.OrganizationId);

//            builder.HasOne(P => P.Customer).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.CustomerId);
//            builder.HasOne(P => P.Authority);
//        }
//    }
//}
