using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel
{
    [CustomEditor(typeof(SimpleDialogue))]
    public class DialogueEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            Dialogue dialogue = (Dialogue) target;
            
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"m_Script");
            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(dialogue.Scenario);
            }
        }
    }
}