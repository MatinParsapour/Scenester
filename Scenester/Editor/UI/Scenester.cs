using System;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.Inspector;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI
{
    public class Scenester : EditorWindow
    {

        private static Scenester _scenester;
        

        [MenuItem("Window/Scenester/Scene Director")]
        public static void Open()
        {
            Scenester scenester = GetWindow<Scenester>(typeof(SceneView));
            scenester.titleContent = new GUIContent("Scene Director");
        }

        private void OnEnable()
        {
            rootVisualElement.Add(ActionBar.GetInstance());
            rootVisualElement.Add(SceneContainer.GetInstance());
            new AddScenarioButton().CreateNewScenario();
        }

        private void OnDisable()
        {
            SceneUnitInspector.GetInstance(null).Close();
        }
    }
}