using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;

namespace Dastan.Scenester.Editor.Services
{
    public interface IScenarioLoader : IService
    {
        
        public Scenario LoadScenarioPanel();
        
        public void OpenScenario(ScenarioUI scenarioUI);
        
    }
}