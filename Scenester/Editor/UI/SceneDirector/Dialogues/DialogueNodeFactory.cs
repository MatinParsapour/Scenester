using System;
using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Dialogues;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class DialogueNodeFactory
    {
        
        private static T CreateDialogue<T>(Scenario scenario, Vector2 position) where T : DialogueUI
        {
            T simpleDialogueUI = (T) Activator.CreateInstance(typeof(T), new object[] {DialogueFactory.CreateSimpleDialogue(scenario, position)});
            simpleDialogueUI.SetPosition(new Rect(position, new Vector2(100, 100)));
            return simpleDialogueUI;
        }
        
        public static SimpleDialogueUI CreateSimpleDialogue(Scenario scenario, Vector2 position)
        {
            return CreateDialogue<SimpleDialogueUI>(scenario, position);
        }
    }
}