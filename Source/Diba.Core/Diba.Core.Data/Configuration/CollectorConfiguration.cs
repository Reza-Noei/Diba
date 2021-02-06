using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    internal class CollectorConfiguration : IEntityTypeConfiguration<Collector>
    {
        public void Configure(EntityTypeBuilder<Collector> builder)
        {
            builder.ToTable("Collectors");
        }
    }
}
