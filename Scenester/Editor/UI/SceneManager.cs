using System.Collections;
using System.Threading;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Services;
using Dastan.Scenester.Editor.Services.Impl;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI
{
    
    
    public class SceneManager
    { 
        private static readonly ScenarioSaveAgentService ScenarioAgent = new ScenarioSaveAgentService();
        private static readonly DialogueSaveAgentService DialogueAgent = new DialogueSaveAgentService();
        
        private static float threadProgress;
        private static bool done;
        
        public static void AddScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance(null).Add(scenarioButtonContainer);
        }

        public static void DeleteScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance(null).Remove(scenarioButtonContainer);
        }

        public static int SizeScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            return TabBar.GetInstance(scenarioButtonContainer).childCount;
        }

        public static IEnumerator Save(Scenario scenario)
        {
            try
            {
                EditorUtility.DisplayProgressBar("Saving...", "Working...", 0);
                bool success = ScenarioAgent.Save(scenario);
                EditorUtility.DisplayProgressBar("Saving...", "Working...", 10);
                if (success)
                {
                    foreach (Dialogue dialogue in scenario.GetDialogues())
                    {
                        DialogueAgent.Save(dialogue);
                    }
                }
                yield return null;
                EditorUtility.DisplayProgressBar("Saving...", "Working...", 100);
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

        }
    }
}