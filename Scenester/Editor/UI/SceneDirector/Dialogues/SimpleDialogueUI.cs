using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using Dastan.Scenester.Editor.util;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Dialogues
{
    public class SimpleDialogueUI : DialogueUI
    {
        public SimpleDialogueUI(Dialogue dialogue) : base(dialogue)
        {
            inputContainer.Add(PortUtil.CreatePort(Direction.Input, Port.Capacity.Single));
            outputContainer.Add(PortUtil.CreatePort(Direction.Output, Port.Capacity.Single));

            RefreshExpandedState();
            RefreshPorts();
        }
    }
}