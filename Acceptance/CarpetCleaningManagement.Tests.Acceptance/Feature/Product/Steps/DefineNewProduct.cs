using System;
using Diba.Tests.Acceptance.Feature.Product.Mappers;
using Diba.Tests.Acceptance.Feature.Product.Model;
using Diba.Tests.Acceptance.Feature.Product.Tasks.Posts;
using Newtonsoft.Json.Linq;
using NFluent;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Questions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Diba.Tests.Acceptance.Feature.Product.Steps
{
    [Binding]
    public class DefineNewProduct
    {
        private readonly Stage _stage;

        public DefineNewProduct(Stage stage)
        {
            _stage = stage;
        }

        [Given(@"'(.*)' is an administrador")]
        public void GivenIsAnAdministrador(string actorName)
        {
            this._stage.ShineSpotlightOn(actorName);
        }

        [Given(@"'(.*)' is\(has\) logged in")]
        public void GivenIsHasLoggedIn(string p0)
        {
            //todo:It will be completed later
        }

        [Given(@"there is constraints in system as following")]
        public void GivenThereIsConstraintsInSystemAsFollowing(Table table)
        {
            //todo:It will be completed later
        }

        [When(@"'(.*)' has define a product in system as following")]
        public void WhenHasDefineAProductInSystemAsFollowing(string actorName, Table product)
        {
            var createProductCommand = product.CreateInstance<CreateProductCommand>();
            createProductCommand.Name += Guid.NewGuid();

            _stage.ActorInTheSpotlight.AttemptsTo(CreateProduct.By(createProductCommand));

            var response = _stage.ActorInTheSpotlight.AsksFor(LastResponse.Raw());
            var productJsonResult = response.Content.ReadAsStringAsync().Result;

            JToken productJson = JObject.Parse(productJsonResult);
            int id = (int)productJson.SelectToken("data.id");

            _stage.ActorInTheSpotlight.Remember("productId", id);
        }

        [When(@"he has assigned the following constraint for it")]
        public void WhenHeHasAssignedTheFollowingConstraintForIt(Table constraints)
        {
            var productId = _stage.ActorInTheSpotlight.Recall<int>("productId");
            var selectiveConstraintsCommand = SelectiveConstraintsMappers.Map(constraints.CreateInstance<SelectiveConstraints>());
            selectiveConstraintsCommand.ProductId = productId;

            _stage.ActorInTheSpotlight.AttemptsTo(AssignSelectiveConstraintsToProduct.By(selectiveConstraintsCommand));

            _stage.ActorInTheSpotlight.Remember("SelectiveConstraintsTitle", selectiveConstraintsCommand.Title);
        }

        [Then(@"It should be available in the list of products")]
        public void ThenItShouldBeAvailableInTheListOfProducts()
        {
            var response = _stage.ActorInTheSpotlight.AsksFor(LastResponse.Raw());
            var productWithConstraintsResult = response.Content.ReadAsStringAsync().Result;
            JToken productJson = JObject.Parse(productWithConstraintsResult);
            string title = productJson.SelectToken("data.title").ToString();

            var selectiveConstraintsTitle = _stage.ActorInTheSpotlight.Recall<string>("SelectiveConstraintsTitle");

            //todo: complete
            Check.That(selectiveConstraintsTitle).IsEqualTo(title);
        }

    }
}