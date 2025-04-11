using Dastan.Scenester.Editor.Entity.Base;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class DialogueSaveAgentService : SceneUnitSaveAgent<Dialogue>
    {
        public override bool Save(Dialogue dialogue)
        {
            if (!EditorUtility.IsDirty(dialogue))
            {
                return true;
            }
            
            if (!AssetDatabase.IsValidFolder($"{ScenariosPath}/{dialogue.Scenario.key}/Dialogues"))
            {
                AssetDatabase.CreateFolder($"{ScenariosPath}/{dialogue.Scenario.key}", "Dialogues");
            }

            if (string.IsNullOrEmpty(AssetDatabase.GetAssetPath(dialogue)))
            {
                AssetDatabase.CreateAsset(dialogue, AssetDatabase.GenerateUniqueAssetPath($"{ScenariosPath}/{dialogue.Scenario.key}/Dialogues/{dialogue.key}.asset"));
            } else
            {
                if (dialogue.isNew)
                {
                    bool result = EditorUtility.DisplayDialog("Overwrite Warning","There's a dialogue with the same key already exists. \nDo you want to overwrite it?", "Yes","No");
                    if (result)
                    {
                        AssetDatabase.ImportAsset((AssetDatabase.GetAssetPath(dialogue)));
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    AssetDatabase.ImportAsset((AssetDatabase.GetAssetPath(dialogue)));
                }
            }
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.ClearDirty(dialogue);
            dialogue.isNew = false;
            return true;
        }
    }
}