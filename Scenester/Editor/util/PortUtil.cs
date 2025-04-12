using Dastan.Scenester.Editor.UI.SceneDirector.Core;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.util
{
    public class PortUtil
    {
        public static Port CreatePort(Direction direction, Port.Capacity capacity)
        {
            var port = Port.Create<Edge>(Orientation.Horizontal, direction, capacity, typeof(bool));
            port.portName = "In";
            port.name = "Input";
            port.AddManipulator(new EdgeConnector<Edge>(new EdgeConnectorListener()));
            return port;
        }
    }
}