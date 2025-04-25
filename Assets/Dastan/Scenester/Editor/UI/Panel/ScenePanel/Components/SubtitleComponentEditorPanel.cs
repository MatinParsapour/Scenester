using Dastan.Scenester.Editor.Entity.Components;
using UnityEditor;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel.Components
{
    [CustomEditor(typeof(SubtitleComponent))]
    public class SubtitleComponentEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"m_Script");
            serializedObject.ApplyModifiedProperties();
        }
    }
}