namespace Dastan.Scenester.Editor.UI.Btn
{
    public class ScenarioCloseButton : ScenesterButton
    {
        
        private readonly ScenarioButtonContainer _scenarioButtonContainer;

        public ScenarioCloseButton(ScenarioButtonContainer scenarioButtonContainer)
        {
            _scenarioButtonContainer = scenarioButtonContainer;
            clicked += DeleteScenario;
        }

        private void DeleteScenario()
        {
            SceneManager.DeleteScene(_scenarioButtonContainer);
        }
    }
}