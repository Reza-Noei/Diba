using Diba.Tests.Acceptance.Feature.Product.Model;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Posts
{

    public class AssignSelectiveConstraintsToProductBy : IPerformable
    {
        private readonly SelectiveConstraintsCommand _command;

        public AssignSelectiveConstraintsToProductBy(SelectiveConstraintsCommand command)
        {
            _command = command;
        }

        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_command).To($"/api/product/{_command.ProductId}/SelectiveConstraints"));
        }
    }
}