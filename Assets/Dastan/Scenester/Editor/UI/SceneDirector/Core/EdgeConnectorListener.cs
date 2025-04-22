using Dastan.Scenester.Editor.Entity.Dialogues;
using Dastan.Scenester.Editor.UI.SceneDirector.Dialogues;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Core
{
    public class EdgeConnectorListener : IEdgeConnectorListener
    {
        public void OnDrop(GraphView graphView, Edge edge)
        {
            SimpleDialogueUI output = edge.output.node as SimpleDialogueUI;
            SimpleDialogueUI input = edge.input.node as SimpleDialogueUI;
            input?.Dialogue.AddNext(output?.Dialogue);
        }

        public static void OnDelete(Edge edge)
        {
            SimpleDialogueUI input = edge.input.node as SimpleDialogueUI;
            input?.Dialogue.RemoveNext();
        }

        public void OnDropOutsidePort(Edge graphView, Vector2 position) { }
    }
}