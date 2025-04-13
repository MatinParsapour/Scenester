using System.Collections.Generic;
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

        private Dialogue _dialogue;
        private readonly List<UnityEditor.Editor> _componentEditors = new List<UnityEditor.Editor>();

        private void OnEnable()
        {
            _dialogue = (Dialogue)target;
            
            CreateComponents();
        }

        private void CreateComponents()
        {
            foreach (UnityEditor.Editor editor in _componentEditors)
            {
                DestroyImmediate(editor);
            }
            _componentEditors.Clear();
            
            
            foreach (Entity.Base.Component component in _dialogue.components)
            {
                _componentEditors.Add(CreateEditor(component));
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"m_Script");
            serializedObject.ApplyModifiedProperties();

            foreach (UnityEditor.Editor editor in _componentEditors)
            {
                if (editor != null)
                {
                    EditorGUILayout.BeginVertical("box");
                    editor.OnInspectorGUI();
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.Space();
                }
            }
            
            var rect = GetButtonRectangular();

            if (GUI.Button(rect, "Add Component"))
            {
                Rect panelRect = GUIUtility.GUIToScreenRect(rect);
                ComponentPopupPanel.Show(this, panelRect, _dialogue);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_dialogue.Scenario);
                EditorUtility.SetDirty(_dialogue);
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

        public void AddComponent(Entity.Base.Component component)
        {
            _componentEditors.Add(CreateEditor(component));
        }
    }
}