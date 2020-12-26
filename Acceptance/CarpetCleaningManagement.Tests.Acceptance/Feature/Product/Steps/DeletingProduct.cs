using Diba.Tests.Acceptance.Feature.Product.Mappers;
using Diba.Tests.Acceptance.Feature.Product.Model;
using Diba.Tests.Acceptance.Feature.Product.Tasks.Deletes;
using Diba.Tests.Acceptance.Feature.Product.Tasks.Posts;
using Newtonsoft.Json.Linq;
using NFluent;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Diba.Tests.Acceptance.Feature.Product.Steps
{
    [Binding]
    public class DeletingProduct
    {
        private readonly Actor _actor;

        public DeletingProduct(Stage stage)
        {
            _actor = stage.ActorInTheSpotlight;
        }

        [Given(@"he has assigned the following constraint for it")]
        public void GivenHeHasAssignedTheFollowingConstraintForIt(Table constraints)
        {
            var productId = _actor.Recall<int>("productId");
            var selectiveConstraintsCommand = SelectiveConstraintsMappers.Map(constraints.CreateInstance<SelectiveConstraints>());
            selectiveConstraintsCommand.ProductId = productId;

            _actor.AttemptsTo(AssignSelectiveConstraintsToProduct.By(selectiveConstraintsCommand));

            var response = _actor.AsksFor(LastResponse.Raw());
            var productJsonResult = response.Content.ReadAsStringAsync().Result;

            JToken productJson = JObject.Parse(productJsonResult);
            int id = (int)productJson.SelectToken("data.id");

            _actor.Remember("constraintsId", id);
        }

        [When(@"he removes the product defined above")]
        public void WhenHeRemovesTheProductDefinedAbove()
        {
            var productId = _actor.Recall<int>("productId");
            _actor.AttemptsTo(DeleteProduct.By(productId));
        }
        
        [Then(@"It should not appear in the list of products")]
        public void ThenItShouldNotAppearInTheListOfProducts()
        {
            var productId = _actor.Recall<int>("productId");
            _actor.AttemptsTo(Get.ResourceAt($"/api/Product/{productId}"));

            var response = _actor.AsksFor(LastResponse.Raw());
            var productJsonResult = response.Content.ReadAsStringAsync().Result;
            JToken productJson = JObject.Parse(productJsonResult);
            var data = productJson.SelectToken("data").ToString();

            Check.That(data).IsEqualTo("");
        }

    }
}