using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.util;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class EntryDialogueUI : DialogueUI
    {
        public EntryDialogueUI(Dialogue dialogue) : base(dialogue)
        {
            inputContainer.Add(PortUtil.CreatePort(Direction.Input, Port.Capacity.Multi));
            
            RefreshExpandedState();
            RefreshPorts();
        }
    }
}