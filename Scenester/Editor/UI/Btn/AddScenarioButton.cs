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

        private void CreateNewScenario()
        {
            SceneManager.AddScene(new ScenarioButtonContainer(new ScenarioUI(ScriptableObject.CreateInstance<Scenario>())));
        }
    }
}