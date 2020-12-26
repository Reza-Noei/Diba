using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Deletes
{

    public class DeleteProductBy : IPerformable
    {
        private readonly int _id;
        public DeleteProductBy(int id)
        {
            _id = id;
        }
        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Delete.From($"/api/product/{_id}"));
        }
    }
}