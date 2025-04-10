using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class SimpleDialogueUI : DialogueUI
    {
        public SimpleDialogueUI(Dialogue dialogue) : base(dialogue)
        {
            // No additional port creation needed here, the base class handles it.
            // The important part is that the base constructor IS being called.
        }
    }
}