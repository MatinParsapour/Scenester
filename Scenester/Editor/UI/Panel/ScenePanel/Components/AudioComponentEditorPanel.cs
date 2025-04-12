using Dastan.Scenester.Editor.Entity.Components;
using UnityEditor;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel
{
    [CustomEditor(typeof(AudioComponent))]
    public class AudioComponentEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            // base.OnInspectorGUI();
            
            EditorGUILayout.TextField("Name", "");
        }
    }
}