using Dastan.Scenester.Editor.Entity.Base;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel
{
    
    [CustomEditor(typeof(Scenario))]
    public class ScenarioEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            Scenario scenario = (Scenario)target;

            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject, "m_Script");
            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(scenario);
            }
        }
    }
}