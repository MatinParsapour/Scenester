using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using UnityEngine;
using Component = Dastan.Scenester.Editor.Entity.Base.Component;

namespace Dastan.Scenester.Editor.Entity.Dialogues
{
    public class DialogueFactory
    {

        private static T CreateDialogue<T>(Scenario scenario, Vector2 position, string prefix) where T : Dialogue
        {
            T dialogue = ScriptableObject.CreateInstance<T>();
            dialogue.Scenario = scenario;
            dialogue.key = prefix + " " + (scenario.GetDialogues().Count + 1);
            dialogue.components = new List<Component>();
            scenario.AddDialogue(dialogue, position);
            return dialogue;
        }

        public static SimpleDialogue CreateSimpleDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<SimpleDialogue>(scenario, position, "Simple Dialogue");
        } 
    }
}