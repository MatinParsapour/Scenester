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

            string path = "Assets" + scenarioPath.Substring(Application.dataPath.Length);
            return LoadScenario(path);
            
        }

        public Scenario LoadScenario(string path)
        {
            Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);
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
    }
}