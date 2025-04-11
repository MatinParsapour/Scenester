using System.Collections.Generic;
using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Entity.Base;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public abstract class Dialogue : SceneUnit
    {
        [HideInInspector] 
        private readonly List<Port> _inputPorts = new List<Port>();
        private readonly List<Port> _outputPorts = new List<Port>();
        public Scenario Scenario { get; set; }
        
        private readonly List<Component> _components = new List<Component>();

        protected Dialogue(SceneUnitType type, Scenario scenario): base(type)
        {
            Scenario = scenario;
        }

        private void UpdatePorts(Port port, bool add, List<Port> ports)
        {
            if (add)
            {
                ports.Add(port);
            }
            else
            {
                ports.Remove(port);
            }
            
            EditorUtility.SetDirty(Scenario);
        }

        private void UpdateComponents(Component component, bool add)
        {
            if (add)
            {
                _components.Add(component);
            }
            else
            {
                _components.Remove(component);
            }
            
            EditorUtility.SetDirty(Scenario);
        }
        
        public void AddInput(Port port)
        {
            UpdatePorts(port, true, _inputPorts); 
        }

        public void RemoveInput(Port port)
        {
            UpdatePorts(port, false, _inputPorts);
        }

        public void AddOutput(Port port)
        {
            UpdatePorts(port, true, _outputPorts);
        }

        public void RemoveOutput(Port port)
        {
            UpdatePorts(port, false, _outputPorts);
        }

        public void AddComponent(Component component)
        {
            UpdateComponents(component, true);
        }
        
        public void RemoveComponent(Component component)
        {
            UpdateComponents(component, false);
        }

        public abstract Dialogue Execute();
    }
}