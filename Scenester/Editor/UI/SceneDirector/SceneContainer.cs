using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector
{
    public class SceneContainer : VisualElement
    {

        private static SceneContainer _instance;
        private ScenarioUI _activeScenario;

        public static SceneContainer GetInstance()
        {
            return _instance ??= new SceneContainer(new ScenarioUI(ScriptableObject.CreateInstance<Scenario>()));
        }

        private SceneContainer(ScenarioUI scenarioUI)
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            AddToClassList("one-flex-grow");
            ChangeUI(scenarioUI);
        }

        public void ChangeUI(ScenarioUI scenarioUI)
        {
            _activeScenario = scenarioUI;
            Clear();
            scenarioUI.StretchToParentSize();
            Add(scenarioUI);
        }

        public ScenarioUI GetActiveScenario()
        {
            return _activeScenario;
        }
    }
}