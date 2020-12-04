using System;
using System.Collections.Generic;
using Diba.Core.Domain.Products.ProductConstraints;
using FluentAssertions;
using Xunit;

namespace Diba.Core.Domain.Unit.Test.Model.Products.ProductConstraints
{
    public class SelectiveConstraintTests
    {
        //TODO: refactor this tests

        [Fact]
        public void Constructor_should_create_selective_constraint()
        {
            var weavingType = 1;
            var machine = new Option("Machine", 1);
            var handmade = new Option("Handmade ", 2);
            var options = new List<Option>() { machine, handmade };

            var constraint = new SelectiveConstraint(weavingType, options);

            constraint.ConstraintId.Should().Be(weavingType);
            constraint.Options.Should().BeEquivalentTo(options);
        }

        [Fact]
        public void Constructor_should_throw_if_options_have_duplicate_values()
        {
            var weavingType = 1;
            var machine = new Option("Machine", 1);
            var handmade = new Option("Handmade ", 1);
            var options = new List<Option>() { machine, handmade };

            Action constructor = () => new SelectiveConstraint(weavingType, options);

            constructor.Should().Throw<DuplicateOptionException>();
        }


        [Fact]
        public void Validate_should_return_true_if_value_present_in_keys()
        {
            var weavingType = 1;
            var machine = new Option("Machine", 1);
            var handmade = new Option("Handmade ", 2);
            var options = new List<Option>() { machine, handmade };
            var constraint = new SelectiveConstraint(weavingType, options);
            var value = 1;

            var result = constraint.Validate(value);

            result.Should().BeTrue();
        }

        [Fact]
        public void Validate_should_return_false_if_value_is_not_present_in_keys()
        {
            var weavingType = 1;
            var machine = new Option("Machine", 1);
            var handmade = new Option("Handmade ", 2);
            var options = new List<Option>() { machine, handmade };
            var constraint = new SelectiveConstraint(weavingType, options);
            var value = 10;

            var result = constraint.Validate(value);

            result.Should().BeFalse();
        }
    }
}
