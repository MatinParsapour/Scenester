using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;
using Component = Dastan.Scenester.Editor.Entity.Base.Component;

namespace Dastan.Scenester.Editor.Entity.Dialogues
{
    public class DialogueFactory
    {

        private static T CreateDialogue<T>(Scenario scenario, Vector2 position, SceneUnitType type, string prefix) where T : Dialogue
        {
            T dialogue = ScriptableObject.CreateInstance<T>();
            dialogue.Scenario = scenario;
            dialogue.key = prefix + " " + (scenario.GetDialogues().Count + 1);
            dialogue.components = new List<Component>();
            dialogue.nextDialogues = new List<Dialogue>();
            dialogue.type = type;
            dialogue.Position = position;
            scenario.AddDialogue(dialogue);
            return dialogue;
        }

        public static SimpleDialogue CreateSimpleDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<SimpleDialogue>(scenario, position, SceneUnitType.SimpleDialogue, "Simple Dialogue");
        }

        public static EntryDialogue CreateEntryDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<EntryDialogue>(scenario, position, SceneUnitType.Entry, "Entry Dialogue");
        }
    }
}