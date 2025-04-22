using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public class ScenarioFactory
    {


        public static Scenario CreateScenario()
        {
            Scenario scenario = ScriptableObject.CreateInstance<Scenario>();
            scenario.entryDialogue = ScriptableObject.CreateInstance<EntryDialogue>();
            return scenario;
        }
        
    }
}