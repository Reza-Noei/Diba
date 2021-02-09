using Diba.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Configuration
{
    internal class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
    {
        public void Configure(EntityTypeBuilder<Secretary> builder)
        {
            //builder.ToTable("Secretaries");
        }
    }
}
