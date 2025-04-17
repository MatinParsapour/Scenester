using System.IO;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class ScenarioLoaderImpl : IScenarioLoader
    {

        private readonly string _defaultScenariosPath = "Assets/Dastan/Scenester/Resources/Scenarios";
        
        public Scenario LoadScenarioPanel()
        {
            string scenarioPath = EditorUtility.OpenFilePanel("Select Scenario", _defaultScenariosPath, "asset");
            if (string.IsNullOrEmpty(scenarioPath))
            {
                return null;
            }
            
            Object obj = AssetDatabase.LoadAssetAtPath<Object>("Assets" + scenarioPath.Substring(Application.dataPath.Length));
            if (obj is not Scenario scenario)
            {
                EditorUtility.DisplayDialog("Error", "The selected file is not a scenario.", "OK");
                return LoadScenarioPanel();
            }

            if (scenario.type != SceneUnitType.Scenario)
            {
                EditorUtility.DisplayDialog("Error", "The selected file is not a scenario.", "OK");
                return LoadScenarioPanel();
            }
            
            return scenario;
            
        }

        public void OpenScenario(ScenarioUI scenarioUI)
        {
            if (scenarioUI.Scenario.isNew)
            {
                AddEntryDialogue(scenarioUI);
            }
        }

        private static void AddEntryDialogue(ScenarioUI scenarioUI)
        {
            scenarioUI.schedule.Execute(() =>
            {
                const float offset = 200;
                scenarioUI.AddElement(DialogueNodeFactory.CreateEntryDialogue(scenarioUI.Scenario, new Vector2(scenarioUI.contentContainer.resolvedStyle.width - offset, (scenarioUI.contentContainer.resolvedStyle.height / 2))));
            }).ExecuteLater(300);
        }
    }
}