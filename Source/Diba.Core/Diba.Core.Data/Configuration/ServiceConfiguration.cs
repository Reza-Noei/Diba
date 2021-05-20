using System.Collections.Generic;
using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Diba.Core.Data.Configuration
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(p => p.Product).WithMany(p => p.Services).IsRequired();
            builder
                .Property(e => e.FeeByBrand)
                .IsRequired()
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => v == null
                        ? new Dictionary<long, decimal>() 
                        : JsonConvert.DeserializeObject<Dictionary<long, decimal>>(v)
                );

        }
    }
}