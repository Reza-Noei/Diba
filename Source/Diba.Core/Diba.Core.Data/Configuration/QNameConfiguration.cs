using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class QNameConfiguration : IEntityTypeConfiguration<QName>
    {
        public void Configure(EntityTypeBuilder<QName> builder)
        {
            builder.ToTable("QNames");

            builder.HasKey(P => P.Id);
            builder.Property(P => P.Id).ValueGeneratedOnAdd();
        }
    }
}
