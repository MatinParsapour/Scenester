using Dastan.Scenester.Editor.Entity.Components;
using Dastan.Scenester.ReferenceManagement;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.Panel.ScenePanel.Components
{
    [CustomEditor(typeof(AudioComponent))]
    public class AudioComponentEditorPanel : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AudioComponent audioComponent = (AudioComponent)target;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Audio Source Linking", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();
            GameObject droppedObject = (GameObject)EditorGUILayout.ObjectField(
                "Audio Source Object",
                audioComponent.audioSource,
                typeof(GameObject),
                true);

            if (EditorGUI.EndChangeCheck())
            {
                if (droppedObject != null)
                {
                    ScenesterObject uniqueID = droppedObject.GetComponent<ScenesterObject>();
                    if (uniqueID == null)
                    {
                        uniqueID = droppedObject.AddComponent<ScenesterObject>();
                        EditorUtility.SetDirty(droppedObject);
                        Debug.Log($"[AutoID] Attached ScenesterObject to '{droppedObject.name}'");
                    }

                    audioComponent.audioSourceID = uniqueID.ID; // Save the ID string
                    audioComponent.editorAudioSourceObject = droppedObject; // Save the reference for Editor only
                    EditorUtility.SetDirty(audioComponent);
                }
                else
                {
                    audioComponent.audioSourceID = "";
                    audioComponent.editorAudioSourceObject = null;
                    EditorUtility.SetDirty(audioComponent);
                }
        }
    }
}