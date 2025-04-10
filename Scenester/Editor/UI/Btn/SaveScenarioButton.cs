using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public class SaveScenarioButton : ScenesterButton
    {

        public SaveScenarioButton()
        {
            clicked += Save;
        }
        
        private void Save()
        {
            Debug.Log(SceneContainer.GetInstance().GetActiveScenario().Scenario.key);
            foreach (Dialogue dialogue in SceneContainer.GetInstance().GetActiveScenario().Scenario.GetDialogues())
            {
                Debug.Log(dialogue.key);
            }
        }
    }
}