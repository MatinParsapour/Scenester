using System.Collections.Generic;
using System.Linq;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Edge = UnityEditor.Experimental.GraphView.Edge;

namespace Dastan.Scenester.Editor.Services.Impl
{
    public class DialogueRendererImpl : IDialogueRenderer
    {
        public void RenderDialogue(ScenarioUI scenarioUI, DialogueUI dialogueUI)
        {
            List<Dialogue> nextDialogues = dialogueUI.Dialogue.nextDialogues.ToList();
            Scenario scenario = scenarioUI.Scenario;
            
            foreach (Dialogue nextDialogue in nextDialogues)
            {
                DialogueUI nextDialogueUI = DialogueNodeFactory.CreateDialogue(scenario, nextDialogue.Position, nextDialogue);
                Port fromPort = dialogueUI.inputContainer.Q<Port>("input");
                Port toPort = nextDialogueUI.outputContainer.Q<Port>("output");
                Edge edge = new Edge
                {
                    output = fromPort, 
                    input = toPort
                };
                
                fromPort.Connect(edge);
                toPort.Connect(edge);
                scenarioUI.AddElement(nextDialogueUI);
                scenarioUI.AddElement(edge);
                RenderDialogue(scenarioUI, nextDialogueUI);
            }
        }
    }
}