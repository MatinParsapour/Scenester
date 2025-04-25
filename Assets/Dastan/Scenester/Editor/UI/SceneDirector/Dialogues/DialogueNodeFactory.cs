using System;
using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using OpenCover.Framework.Model;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class DialogueNodeFactory
    {

        private static readonly Dictionary<SceneUnitType, Func<Scenario, Vector2, Dialogue, DialogueUI>> NewDialogueUI = new Dictionary<SceneUnitType, Func<Scenario, Vector2, Dialogue, DialogueUI>>()
        {
            { SceneUnitType.SimpleDialogue, CreateSimpleDialogue },
            { SceneUnitType.Entry, CreateEntryDialogue }
        };
        
        private static T CreateDialogue<T>(Vector2 position, Dialogue dialogue) where T : DialogueUI
        {
            T dialogueUI = (T) Activator.CreateInstance(typeof(T), new object[] {dialogue});
            dialogueUI.SetPosition(new Rect(position, new Vector2(100, 100)));
            return dialogueUI;
        }
        
        public static SimpleDialogueUI CreateSimpleDialogue(Scenario scenario, Vector2 position, Dialogue dialogue)
        {
            dialogue ??= DialogueFactory.CreateSimpleDialogue(scenario, position);
            return CreateDialogue<SimpleDialogueUI>(position, dialogue);
        }

        public static EntryDialogueUI CreateEntryDialogue(Scenario scenario, Vector2 position, Dialogue dialogue)
        {
            dialogue ??= DialogueFactory.CreateEntryDialogue(scenario, position);
            EntryDialogueUI entryDialogueUI = CreateDialogue<EntryDialogueUI>(position, dialogue);
            scenario.entryDialogue = entryDialogueUI.Dialogue as EntryDialogue;
            return entryDialogueUI;
        }

        public static DialogueUI CreateDialogue(Scenario scenario, Vector2 position, Dialogue dialogue)
        {
            return NewDialogueUI.TryGetValue(dialogue.type, out Func<Scenario, Vector2, Dialogue, DialogueUI> factory) ? factory(scenario, position, dialogue) : null; 
        }
    }
}