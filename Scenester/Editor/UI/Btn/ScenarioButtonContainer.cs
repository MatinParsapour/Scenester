using Dastan.Scenester.Editor.UI.Inspector;
using Dastan.Scenester.Editor.UI.Label;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public class ScenarioButtonContainer : ScenesterButton
    {

        private ScenarioLabel _label;
        private ScenarioCloseButton _closeButton;
        public readonly ScenarioUI ScenarioUI;

        public ScenarioButtonContainer(ScenarioUI scenarioUI)
        { 
            ScenarioUI = scenarioUI;
            ScenarioUI.Scenario.key = "Scenario " + (SceneManager.SizeScene() + 1);
            AddButtons();
            
            Style();
            clicked += ShowScenario;
            ShowScenario();
            HighlightActiveTab();
        }

        private void AddButtons()
        {
            _label = new ScenarioLabel() { text = ScenarioUI.Scenario.key };
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
            SceneContainer.GetInstance().ChangeUI(ScenarioUI);
            SceneUnitInspector.GetInstance(ScenarioUI.Scenario).ChangeInspector();
            TabBar.GetInstance().MarkCurrentTab(this);
        }

        public void HighlightActiveTab()
        {
            AddToClassList("tab-container-active");
        }

        public void UnhighlightInactiveTab()
        {
            RemoveFromClassList("tab-container-active");
        }
        
    }
}