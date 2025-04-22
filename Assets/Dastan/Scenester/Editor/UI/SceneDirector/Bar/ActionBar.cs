using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Bar
{
    public class ActionBar : VisualElement
    {
        public ToolBar Toolbar { get; private set; } = ToolBar.Initialize();
        public TabBar TabBar { get; private set; } = TabBar.GetInstance();

        private static ActionBar _instance;

        public static ActionBar GetInstance()
        {
            return _instance ??= new ActionBar();
        }
        
        private ActionBar()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Bar.uss"));
            AddToClassList("row-flex-direction");
            Add(Toolbar);
            Add(TabBar);
        }
    }
}