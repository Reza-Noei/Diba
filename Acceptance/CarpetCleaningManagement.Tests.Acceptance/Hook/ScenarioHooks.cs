using System.Collections.Generic;
using BoDi;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;
using TechTalk.SpecFlow;

namespace Diba.Tests.Acceptance.Hook
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
            var cast = Cast.WhereEveryoneCan(new List<IAbility>() { CallAnApi.At("http://localhost:60123") });
            var stage = new Stage(cast);
            _container.RegisterInstanceAs(stage);
        }
    }
}