using Unity.EditorCoroutines.Editor;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public class LoadScenarioButton : ScenesterButton
    {

        public LoadScenarioButton()
        {
            clicked += LoadScenario;
        }

        private void LoadScenario()
        {
            EditorCoroutineUtility.StartCoroutine(SceneManager.Load(), this);
        }
        
    }
}