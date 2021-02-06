//using Diba.Core.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Diba.Core.Data.Configuration
//{
//    internal class SuperAdminMembershipConfiguration : IEntityTypeConfiguration<SuperAdminMembership>
//    {
//        public void Configure(EntityTypeBuilder<SuperAdminMembership> builder)
//        {
//            builder.ToTable("SuperAdminMemberships");

//            builder.HasKey(P => P.Id);
//            builder.Property(P => P.Id).ValueGeneratedOnAdd();

//            builder.HasOne(P => P.Organization).WithMany(Q => Q.SuperAdminMemberships).HasForeignKey(P => P.OrganizationId);
//            builder.HasOne(P => P.SuperAdmin).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.SuperAdminId);
//            builder.HasOne(P => P.Authority);
//        }
//    }
//}
