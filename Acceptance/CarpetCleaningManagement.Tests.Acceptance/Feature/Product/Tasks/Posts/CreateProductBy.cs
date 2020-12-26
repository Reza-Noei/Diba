using Diba.Tests.Acceptance.Feature.Product.Model;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Posts
{
    public class CreateProductBy : IPerformable
    {
        private readonly CreateProductCommand _command;

        public CreateProductBy(CreateProductCommand command)
        {
            _command = command;
        }

        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_command).To($"/api/Product"));
        }
    }

}