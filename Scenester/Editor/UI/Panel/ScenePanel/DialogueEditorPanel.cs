using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using Dastan.Scenester.Editor.UI.Panel.Component;
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

            
            var rect = GetButtonRectangular();

            if (GUI.Button(rect, "Add Component"))
            {
                Rect panelRect = GUIUtility.GUIToScreenRect(rect);
                ComponentPopupPanel.Show(panelRect, dialogue);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(dialogue.Scenario);
                EditorUtility.SetDirty(dialogue);
            }
        }

        private static Rect GetButtonRectangular()
        {
            const float padding = 30f;
            const float multiplier = 5f;
            const float height = 20f;
            var width = EditorGUIUtility.currentViewWidth - (padding * multiplier);

            Rect rect = GUILayoutUtility.GetRect(width, height, GUILayout.ExpandWidth(false));
            rect.x = ((padding * multiplier) / 2);
            return rect;
        }
    }
}