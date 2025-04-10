using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Inspector;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Core
{
    public abstract class DialogueUI : Node
    {
        private readonly Dialogue _dialogue;

        protected DialogueUI(Dialogue dialogue)
        {
            _dialogue = dialogue;
            title = _dialogue.type.ToString();

            var edgeConnectorListener = new EdgeConnectorListener(); // Create a single instance for this node type

            // Input Port (Control Flow)
            var input = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Edge));
            input.portName = "In";
            input.name = "input";
            input.AddManipulator(new EdgeConnector<Edge>(edgeConnectorListener));
            Debug.Log($"EdgeConnector added to input port of {title}");
            inputContainer.Add(input);

            // Output Port (Control Flow)
            var output = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Edge));
            output.portName = "Out";
            output.name = "output";
            output.AddManipulator(new EdgeConnector<Edge>(edgeConnectorListener));
            Debug.Log($"EdgeConnector added to input port of {title}");
            outputContainer.Add(output);

            RefreshExpandedState();
            RefreshPorts();
        }

        public override void OnSelected()
        {
            SceneUnitInspector.GetInstance(_dialogue).ChangeInspector();
        }
    }
}