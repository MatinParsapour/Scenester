using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using UnityEditor;
using UnityEngine;
using Component = Dastan.Scenester.Editor.Entity.Base.Component;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class ScenarioSaveAgentService : SceneUnitSaveAgent<Scenario>
    {
        public override bool Save(Scenario scenario)
        {
            if (!EditorUtility.IsDirty(scenario))
            {
                return true;
            }

            if (!AssetDatabase.IsValidFolder($"{ScenariosPath}/" + scenario.key))
            {
                string folderId = AssetDatabase.CreateFolder($"{ScenariosPath}", scenario.key);
                AssetDatabase.CreateAsset(scenario, AssetDatabase.GenerateUniqueAssetPath($"{AssetDatabase.GUIDToAssetPath(folderId)}/{scenario.key}.asset"));
            }
            else
            {
                if (scenario.isNew)
                {
                    bool result = EditorUtility.DisplayDialog("Overwrite Warning","There's a scenario with the same key already exists. \nDo you want to overwrite it?", "Yes","No");
                    if (result)
                    {
                        AssetDatabase.ImportAsset((AssetDatabase.GetAssetPath(scenario)));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    AssetDatabase.ImportAsset((AssetDatabase.GetAssetPath(scenario)));
                }
            }

            AddDialogueSubAssets(scenario, scenario.entryDialogue, new HashSet<Dialogue>());
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.ClearDirty(scenario);
            scenario.isNew = false;
            return true;
        }

        private void AddDialogueSubAssets(Scenario scenario, Dialogue dialogue, HashSet<Dialogue> addedDialogues)
        {
            if (dialogue == null || addedDialogues.Contains(dialogue))
            {
                return; // already added, or null
            }

            addedDialogues.Add(dialogue);

            if (AssetDatabase.GetAssetPath(dialogue) == "") // means not an asset yet
            {
                AssetDatabase.AddObjectToAsset(dialogue, scenario);
            }

            foreach (Component component in dialogue.components)
            {
                AddComponentSubAssets(scenario, component);
            }

            foreach (var nextDialogue in dialogue.nextDialogues)
            {
                AddDialogueSubAssets(scenario, nextDialogue, addedDialogues);
            }
        }

        private void AddComponentSubAssets(Scenario scenario, Component component)
        {
            if (component == null)
            {
                return;
            }

            if (AssetDatabase.GetAssetPath(component) == "")
            {
                AssetDatabase.AddObjectToAsset(component, scenario);
            }
        }
    }
}