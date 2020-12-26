using System;
using Diba.Tests.Acceptance.Feature.Product.Mappers;
using Diba.Tests.Acceptance.Feature.Product.Model;
using Diba.Tests.Acceptance.Feature.Product.Tasks.Posts;
using Diba.Tests.Acceptance.Feature.Product.Tasks.Puts;
using Newtonsoft.Json.Linq;
using NFluent;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Questions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Diba.Tests.Acceptance.Feature.Product.Steps
{
    [Binding]
    public class ModifyingProduct
    {
        private readonly Actor _actor;

        public ModifyingProduct(Stage stage)
        {
            _actor = stage.ActorInTheSpotlight;
        }

        [Given(@"'(.*)' has define a product in system as following")]
        public void GivenHasDefineAProductInSystemAsFollowing(string actor, Table product)
        {
            var createProductCommand = product.CreateInstance<CreateProductCommand>();
            createProductCommand.Name += Guid.NewGuid();

            _actor.AttemptsTo(CreateProduct.By(createProductCommand));

            var response = _actor.AsksFor(LastResponse.Raw());
            var productJsonResult = response.Content.ReadAsStringAsync().Result;

            JToken productJson = JObject.Parse(productJsonResult);
            int id = (int)productJson.SelectToken("data.id");

            _actor.Remember("productId", id);
        }

        [When(@"he changes the measures given in the example above as following")]
        public void WhenHeChangesTheMeasuresGivenInTheExampleAboveAsFollowing(Table product)
        {
            //todo: complete later
        }

        [When(@"he has assigned the following constraint for it:")]
        public void WhenHeHasAssignedTheFollowingConstraintForIt(Table constraints)
        {
            var productId = _actor.Recall<int>("productId");
            var constraintsId = _actor.Recall<int>("constraintsId");

            var selectiveConstraintsCommand = SelectiveConstraintsMappers.Map(constraints.CreateInstance<SelectiveConstraints>());
            var updateCommand = new ProductSelectiveConstraintsUpdateCommand();

            updateCommand.Title = selectiveConstraintsCommand.Title;
            updateCommand.Options = selectiveConstraintsCommand.Options;
            updateCommand.ProductId = productId;
            updateCommand.Id = constraintsId;

            _actor.AttemptsTo(UpdateProductSelectiveConstraints.By(updateCommand));

            _actor.Remember("SelectiveConstraintsTitle", updateCommand.Title);
        }

        [Then(@"The product has changed with the above information")]
        public void ThenTheProductHasChangedWithTheAboveInformation()
        {
            var response = _actor.AsksFor(LastResponse.Raw());
            var productWithConstraintsResult = response.Content.ReadAsStringAsync().Result;
            JToken productJson = JObject.Parse(productWithConstraintsResult);
            string title = productJson.SelectToken("data.title").ToString();

            var selectiveConstraintsTitle = _actor.Recall<string>("SelectiveConstraintsTitle");

            Check.That(selectiveConstraintsTitle).IsEqualTo(title);
        }

    }
}