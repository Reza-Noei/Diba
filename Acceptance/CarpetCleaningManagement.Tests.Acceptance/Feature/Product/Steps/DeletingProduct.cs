using Suzianna.Core.Screenplay;
using TechTalk.SpecFlow;

namespace CarpetCleaningManagement.Tests.Acceptance.Feature.Product.Steps
{
    [Binding]
    public class DeletingProduct
    {
        private readonly Stage _stage;

        [When(@"he removes the product defined above")]
        public void WhenHeRemovesTheProductDefinedAbove()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"It should not appear in the list of products")]
        public void ThenItShouldNotAppearInTheListOfProducts()
        {
            ScenarioContext.Current.Pending();
        }

    }
}