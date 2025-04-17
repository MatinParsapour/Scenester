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

        private static readonly Dictionary<SceneUnitType, Func<Scenario, Vector2, DialogueUI>> _dialogueUIs = new Dictionary<SceneUnitType, Func<Scenario, Vector2, DialogueUI>>()
        {
            { SceneUnitType.SimpleDialogue, CreateSimpleDialogue },
            { SceneUnitType.Entry, CreateEntryDialogue }
        };
        
        private static T CreateDialogue<T>(Scenario scenario, Vector2 position, Dialogue dialogue) where T : DialogueUI
        {
            T simpleDialogueUI = (T) Activator.CreateInstance(typeof(T), new object[] {dialogue});
            simpleDialogueUI.SetPosition(new Rect(position, new Vector2(100, 100)));
            return simpleDialogueUI;
        }
        
        public static SimpleDialogueUI CreateSimpleDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<SimpleDialogueUI>(scenario, position, DialogueFactory.CreateSimpleDialogue(scenario, position));
        }

        public static EntryDialogueUI CreateEntryDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<EntryDialogueUI>(scenario, position, DialogueFactory.CreateEntryDialogue(scenario, position));
        }

        public static DialogueUI CreateDialogue(Scenario scenario, Vector2 position, Dialogue dialogue)
        {
            return _dialogueUIs.TryGetValue(dialogue.type, out Func<Scenario, Vector2, DialogueUI> factory) ? factory(scenario, position) : null; 
        }
    }
}