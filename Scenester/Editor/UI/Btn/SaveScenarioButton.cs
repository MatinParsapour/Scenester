using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Unity.EditorCoroutines.Editor;
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
            EditorCoroutineUtility.StartCoroutine(SceneManager.Save(SceneContainer.GetInstance().GetActiveScenario().Scenario), this);
        }
    }
}