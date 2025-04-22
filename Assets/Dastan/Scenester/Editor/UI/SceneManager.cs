using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Services;
using Dastan.Scenester.Editor.Services.Impl;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.util;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI
{
    
    
    public class SceneManager
    { 
        private static readonly ScenarioSaveAgentService ScenarioAgent = new ScenarioSaveAgentService();
        private static readonly DialogueSaveAgentService DialogueAgent = new DialogueSaveAgentService();
        private static readonly IScenarioLoader ScenarioLoader = new ScenarioLoaderImpl();
        private static readonly IScenarioRenderer ScenarioRenderer = new ScenarioRendererImpl();
        
        private static float threadProgress;
        private static bool done;
        
        public static void AddScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance().Add(scenarioButtonContainer);
        }

        public static void DeleteScene(ScenarioButtonContainer scenarioButtonContainer)
        {
            TabBar.GetInstance().Remove(scenarioButtonContainer);
            SceneContainer.GetInstance().Clear();
        }

        public static int SizeScene()
        {
            return TabBar.GetInstance().childCount;
        }

        public static IEnumerator Save(Scenario scenario)
        {
            ProgressBarUtility progress = ProgressBarUtility.Initialize("Saving...", "Working...").Progress();
            try
            {
                bool success = ScenarioAgent.Save(scenario);
                progress.SetInfo("Saving Scenario...").Progress();
                // List<Dialogue> dialogues = scenario.GetDialogues();
                // progress.SetIncrementer(90f / dialogues.Count);
                // if (success)
                // {
                //     foreach (Dialogue dialogue in dialogues)
                //     {
                //         DialogueAgent.Save(dialogue);
                //         progress.SetInfo("Saving Dialogue...").Progress();
                //     }
                // }
                yield return null;
                progress.Done();
            }
            finally
            {
                progress.Clear();
            }

        }

        public static IEnumerator Load()
        {
            Scenario scenario = ScenarioLoader.LoadScenarioPanel();
            ScenarioRenderer.OpenScenario(new ScenarioUI(scenario));
            yield return null;
        }
    }
}