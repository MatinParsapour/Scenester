using Dastan.Scenester.Editor.Entity.Components;
using UnityEditor;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel.Components
{
    [CustomEditor(typeof(AudioComponent))]
    public class AudioComponentEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"m_Script");
            serializedObject.ApplyModifiedProperties();
        }
    }
}