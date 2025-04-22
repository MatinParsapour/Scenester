using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Bar
{
    public class TabBar : VisualElement
    {
        private static TabBar _instance;
        private ScenarioButtonContainer _currentScenario;

        public static TabBar GetInstance()
        {
            return _instance ??= new TabBar();
        }

        private TabBar()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Bar.uss"));
            AddToClassList("row-flex-direction");
        }

        public void Add(ScenarioButtonContainer newScenarioButtonContainer)
        {
            ScenarioButtonContainer scenarioButtonContainer = this.Q<ScenarioButtonContainer>(newScenarioButtonContainer.ScenarioUI.Scenario.key);
            if (scenarioButtonContainer == null)
            {
                base.Add(newScenarioButtonContainer);
            }
            
            MarkCurrentTab(newScenarioButtonContainer);
        }


        public void MarkCurrentTab(ScenarioButtonContainer newScenarioButtonContainer)
        {
            _currentScenario?.UnhighlightInactiveTab();
            _currentScenario = newScenarioButtonContainer;
            _currentScenario.HighlightActiveTab();
        }
        
    }
}