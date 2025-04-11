using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class DialogueNodeFactory
    {
        public static SimpleDialogueUI CreateSimpleDialogue(Scenario scenario, Vector2 position)
        {
            SimpleDialogue simpleDialogue = ScriptableObject.CreateInstance<SimpleDialogue>();
            simpleDialogue.Scenario = scenario;
            simpleDialogue.key = "Simple Dialogue " + (scenario.GetDialogues().Count + 1);
            scenario.AddDialogue(simpleDialogue, position);
            SimpleDialogueUI simpleDialogueUI = new SimpleDialogueUI(simpleDialogue);
            simpleDialogueUI.SetPosition(new Rect(position, new Vector2(100, 100)));
            return simpleDialogueUI;
        }
    }
}