using System.Collections.Generic;

namespace CarpetCleaningManagement.Tests.Acceptance.Feature.Product.Model
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public List<ProductConstraintDto> Constraints { get; set; }
    }
}