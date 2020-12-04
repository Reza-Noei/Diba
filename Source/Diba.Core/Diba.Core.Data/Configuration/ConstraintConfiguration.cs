using Diba.Core.Domain.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    public class ConstraintConfiguration : IEntityTypeConfiguration<Constraint>
    {
        public void Configure(EntityTypeBuilder<Constraint> builder)
        {
            builder.ToTable("Constraints");
            builder.HasKey(x => x.Id);
        }
    }
}
