using System.Collections.Generic;
using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using TechTalk.SpecFlow;

namespace CarpetCleaningManagement.Tests.Acceptance.Hook
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _container;
        public ScenarioHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void SetupStage()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility>() { CallAnApi.At("http://localhost:5000") });
            var stage = new Stage(cast);
            _container.RegisterInstanceAs(stage);
        }
    }
}