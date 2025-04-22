using Dastan.Scenester.Editor.UI.Btn;
using UnityEditor;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Bar
{
    public class ToolBar : VisualElement
    {
        private readonly AddScenarioButton _addButton = new AddScenarioButton() {text = "+"};
        private readonly SaveScenarioButton _saveButton = new SaveScenarioButton() {text = "Save"};
        private readonly LoadScenarioButton _loadButton = new LoadScenarioButton() {text = "Load"};

        private static ToolBar _instance;

        public static ToolBar Initialize()
        {
            return _instance ??= new ToolBar();
        } 
        
        private ToolBar()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Bar.uss"));
            Add(_addButton);
            Add(_saveButton);
            Add(_loadButton);
            AddToClassList("row-flex-direction");
        }
    }
}