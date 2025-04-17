using System.Collections.Generic;
using System.Linq;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEngine;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class ScenarioRendererImpl : IScenarioRenderer
    {
        public void OpenScenario(ScenarioUI scenarioUI)
        {
            Scenario scenario = scenarioUI.Scenario;
            Dictionary<Dialogue, Vector2> dialogues = scenario.GetDialogues();

            foreach (var key in dialogues.Keys.ToList())
            {
                Vector2 position = dialogues[key];
                scenarioUI.AddElement(DialogueNodeFactory.CreateDialogue(scenario, position, key));
            }
            
            SceneContainer.GetInstance().ChangeUI(scenarioUI);
        }
    }
}