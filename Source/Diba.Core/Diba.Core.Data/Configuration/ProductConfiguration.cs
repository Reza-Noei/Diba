using Diba.Core.Domain.Products;
using Diba.Core.Domain.Products.ProductConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diba.Core.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.HasMany((System.Linq.Expressions.Expression<System.Func<Product, System.Collections.Generic.IEnumerable<ProductConstraint>>>)(x => (System.Collections.Generic.IEnumerable<ProductConstraint>)x.Constraints)).WithOne(z => z.Product).HasForeignKey(z => z.ProductId);
        }
    }

    public class ProductConstraintConfiguration : IEntityTypeConfiguration<ProductConstraint>
    {
        public void Configure(EntityTypeBuilder<ProductConstraint> builder)
        {
            builder.ToTable("ProductConstraints");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product).WithMany((System.Linq.Expressions.Expression<System.Func<Product, System.Collections.Generic.IEnumerable<ProductConstraint>>>)(z => (System.Collections.Generic.IEnumerable<ProductConstraint>)z.Constraints)).HasForeignKey(x => x.ProductId);
        }
    }

    public class StringConstraintConfiguration : IEntityTypeConfiguration<StringConstraint>
    {
        public void Configure(EntityTypeBuilder<StringConstraint> builder)
        {

        }
    }

    public class SelectiveConstraintConfiguration : IEntityTypeConfiguration<SelectiveConstraint>
    {
        public void Configure(EntityTypeBuilder<SelectiveConstraint> builder)
        {
            builder.HasMany(x => x.Options).WithOne(z => z.SelectiveConstraint).HasForeignKey(z => z.SelectiveConstraintId);
        }
    }
}