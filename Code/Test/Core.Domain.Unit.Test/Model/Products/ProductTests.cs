//using System;
//using System.Collections.Generic;
//using Diba.Core.Domain.Products.ProductConstraints;
//using Diba.Core.Domain.Products;
//using FluentAssertions;
//using Xunit;

//namespace Diba.Core.Domain.Unit.Test.Model.Products
//{
//    public class ProductTests
//    {
//        [Fact]
//        public void Constructor_should_create_product()
//        {
//            var id = 1;
//            var name = "Carpet";
//            var constraints = GetSomeValidConstraints();

//            var product = new Product(id, name, constraints);

//            product.Name.Should().Be(name);
//            product.Id.Should().Be(id);
//            product.Constraints.Should().BeEquivalentTo(constraints);
//        }

//        [Fact]
//        public void Constructor_should_throw_exception_when_product_constraint_is_duplicated()
//        {
//            var id = 1;
//            var name = "Carpet";
//            var constraints = GetSomeDuplicateConstraints();

//            Action constructor = () => new Product(id, name, constraints);

//            constructor.Should().Throw<DuplicateProductConstraintException>();
//        }

//        //TODO: move to a test util
//        // anonymous creation method
//        private static List<ProductConstraint> GetSomeDuplicateConstraints()
//        {
//            var weavingType = 1;
//            var machine = new Option("Machine", 1);
//            var handmade = new Option("Handmade ", 2);
//            var options = new List<Option>() { machine, handmade };
//            var constraint = new SelectiveConstraint(weavingType, options);

//            return new List<ProductConstraint>()
//            {
//                constraint,
//                constraint,
//            };
//        }

//        private static List<ProductConstraint> GetSomeValidConstraints()
//        {
//            var weavingType = 1;
//            var machine = new Option("Machine", 1);
//            var handmade = new Option("Handmade ", 2);
//            var options = new List<Option>() { machine, handmade };
//            var constraint = new SelectiveConstraint(weavingType, options);

//            return new List<ProductConstraint>()
//            {
//                constraint
//            };
//        }
//    }
//}
