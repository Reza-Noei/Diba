using Suzianna.Core.Screenplay;
using TechTalk.SpecFlow;

namespace CarpetCleaningManagement.Tests.Acceptance.Feature.Product.Steps
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
            ScenarioContext.Current.Pending();
        }
        
        [When(@"'(.*)' has define a product in system as following")]
        public void WhenHasDefineAProductInSystemAsFollowing(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he has assigned the following constraint for it")]
        public void WhenHeHasAssignedTheFollowingConstraintForIt(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"It should be available in the list of products")]
        public void ThenItShouldBeAvailableInTheListOfProducts()
        {
            ScenarioContext.Current.Pending();
        }

    }
}