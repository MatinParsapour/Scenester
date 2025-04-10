using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Core
{
    public class EdgeConnectorListener : IEdgeConnectorListener
    {
        public void OnDropOutsidePort(GraphView graphView, Edge edge, Vector2 position) // Note the added 'Edge edge' parameter
        {
            Debug.Log("OnDropOutsidePort");
        }

        public void OnDrop(GraphView graphView, Edge edge)
        {
            Debug.Log($"Edge dropped from {edge.output.node.title}.{edge.output.portName} to {edge.input.node.title}.{edge.input.portName}");
            // Implement your connection logic here
        }

        public void OnDropOutsidePort(GraphView graphView, Vector2 position)
        {
            Debug.Log("OnDropOutsidePort (Old Signature - Remove this if present)");
        }

        public void OnDropOutsidePort(Edge graphView, Vector2 position)
        {
            Debug.Log("OnDropOutsidePort fdsa (Old Signature - Remove this if present)");
        }
    }
}