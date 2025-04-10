using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Bar
{
    public class TabBar : VisualElement
    {
        private static TabBar _instance;

        public static TabBar GetInstance(ScenarioButtonContainer scenarioButtonContainer)
        {
            return _instance ??= new TabBar(scenarioButtonContainer);
        }

        private TabBar(ScenarioButtonContainer scenarioButton)
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Bar.uss"));
            AddToClassList("row-flex-direction");
            Add(scenarioButton);
        }
    }
}