using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public class AddScenarioButton : ScenesterButton
    {

        public AddScenarioButton()
        {
            clicked += CreateNewScenario;
        }

        public void CreateNewScenario()
        {
            ScenarioButtonContainer scenarioButtonContainer = new ScenarioButtonContainer(new ScenarioUI(ScriptableObject.CreateInstance<Scenario>()));
            SceneManager.AddScene(scenarioButtonContainer);
        }
    }
}