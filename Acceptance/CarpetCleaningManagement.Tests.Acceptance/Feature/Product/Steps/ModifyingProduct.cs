using Suzianna.Core.Screenplay;
using TechTalk.SpecFlow;

namespace CarpetCleaningManagement.Tests.Acceptance.Feature.Product.Steps
{
    [Binding]
    public class ModifyingProduct
    {
        private readonly Stage _stage;

        [Given(@"'(.*)' has define a product in system as following")]
        public void GivenHasDefineAProductInSystemAsFollowing(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he has assigned the following constraint for it")]
        public void GivenHeHasAssignedTheFollowingConstraintForIt(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he changes the measures given in the example above as following")]
        public void WhenHeChangesTheMeasuresGivenInTheExampleAboveAsFollowing(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The product has changed with the above information")]
        public void ThenTheProductHasChangedWithTheAboveInformation()
        {
            ScenarioContext.Current.Pending();
        }

    }
}