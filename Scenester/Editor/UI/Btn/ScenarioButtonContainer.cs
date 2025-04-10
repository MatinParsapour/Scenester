using Dastan.Scenester.Editor.UI.Inspector;
using Dastan.Scenester.Editor.UI.Label;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public class ScenarioButtonContainer : ScenesterButton
    {

        private ScenarioLabel _label;
        private ScenarioCloseButton _closeButton;
        private readonly ScenarioUI _scenarioUI;

        public ScenarioButtonContainer(ScenarioUI scenarioUI)
        {
            _scenarioUI = scenarioUI;
            _scenarioUI.Scenario.key = "Scenario " + SceneManager.SizeScene(this);
            AddButtons();
            Style();
            clicked += ShowScenario;
            ShowScenario();
        }

        private void AddButtons()
        {
            _label = new ScenarioLabel() { text = _scenarioUI.Scenario.key };
            _closeButton = new ScenarioCloseButton(this) { text = "×"};
            Add(_label);
            Add(_closeButton);
        }

        private void Style()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Container.uss"));
            AddToClassList("row-flex-direction");
            AddToClassList("tab-container");
        }
        
        private void ShowScenario()
        {
            SceneContainer.GetInstance().ChangeUI(_scenarioUI);
            SceneUnitInspector.GetInstance(_scenarioUI.Scenario).ChangeInspector();
        }
        
    }
}