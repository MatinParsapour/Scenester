using Dastan.Scenester.Editor.Entity.Base;
using UnityEditor;
using UnityEngine;

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

            if (!AssetDatabase.IsValidFolder("Assets/Dastan/Scenester/Resources/Scenarios/" + scenario.key))
            {
                string folderId = AssetDatabase.CreateFolder("Assets/Dastan/Scenester/Resources/Scenarios", scenario.key);
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
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.ClearDirty(scenario);
            scenario.isNew = false;
            return true;
        }
    }
}