using System;
using Dastan.Scenester.Entity.Base;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Inspector
{
    public class SceneUnitInspector : EditorWindow
    {

        private static SceneUnit _sceneUnit;
        private UnityEditor.Editor _editor;

        public static SceneUnitInspector GetInstance(SceneUnit sceneUnit)
        {
            SceneUnitInspector inspector = GetWindow<SceneUnitInspector>(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
            inspector.titleContent = new GUIContent("Scene Inspector");
            _sceneUnit = sceneUnit;
            return inspector;
        }

        public void ChangeInspector()
        {
            if (_sceneUnit is null) return;

            if (ReferenceEquals(_editor, null) || _editor.target != _sceneUnit)
            {
                _editor = UnityEditor.Editor.CreateEditor(_sceneUnit);
            }
        }

        private void OnGUI()
        {
            _editor.OnInspectorGUI();
        }
    }
}