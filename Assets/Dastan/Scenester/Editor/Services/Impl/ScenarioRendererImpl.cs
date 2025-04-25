using System.Collections.Generic;
using System.Linq;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Btn;
using Dastan.Scenester.Editor.UI.SceneDirector;
using Dastan.Scenester.Editor.UI.SceneDirector.Bar;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEngine;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class ScenarioRendererImpl : IScenarioRenderer
    {

        private readonly IDialogueRenderer _dialogueRenderer = new DialogueRendererImpl();
        
        public void OpenScenario(ScenarioUI scenarioUI)
        {
            _dialogueRenderer.RenderDialogue(scenarioUI, scenarioUI.Entry);
            TabBar.GetInstance().Add(new ScenarioButtonContainer(scenarioUI));
        }
    }
}