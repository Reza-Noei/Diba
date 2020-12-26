using Diba.Tests.Acceptance.Feature.Product.Model;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Puts
{
    public class ProductSelectiveConstraintsBy : IPerformable
    {
        private readonly ProductSelectiveConstraintsUpdateCommand _command;

        public ProductSelectiveConstraintsBy(ProductSelectiveConstraintsUpdateCommand command)
        {
            _command = command;
        }
        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Put.DataAsJson(_command).To($"/api/product/{_command.ProductId}/StringConstraints/{_command.Id}"));
        }

    }
}