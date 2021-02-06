//using Diba.Core.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Diba.Core.Data.Configuration
//{
//    internal class AdminMembershipConfiguration : IEntityTypeConfiguration<AdminMembership>
//    {
//        public void Configure(EntityTypeBuilder<AdminMembership> builder)
//        {
//            builder.ToTable("AdminMemberships");
//            builder.HasOne(P => P.Organization).WithMany(Q => Q.AdminMemberships).HasForeignKey(P => P.OrganizationId);

//            builder.HasOne(P => P.Admin).WithMany(Q => Q.Memberships).HasForeignKey(Q => Q.AdminId);
//            builder.HasOne(P => P.Authority);
//        }
//    }
//}
