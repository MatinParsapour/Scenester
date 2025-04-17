using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEditor;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel
{
    [CustomEditor(typeof(EntryDialogue))]
    public class EntryDialogueEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"m_Script", "key");
            serializedObject.ApplyModifiedProperties();

        }
    }
}