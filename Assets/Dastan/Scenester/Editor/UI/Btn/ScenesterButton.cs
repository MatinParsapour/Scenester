using UnityEditor;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.Btn
{
    public abstract class ScenesterButton : Button
    {
        public ScenesterButton()
        {
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Btn.uss"));
            styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dastan/Scenester/Editor/UI/Styles/Common.uss"));
            AddToClassList("button-clear-background");
            AddToClassList("button");
        }
    }
}