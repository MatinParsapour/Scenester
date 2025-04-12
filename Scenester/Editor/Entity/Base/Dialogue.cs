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
        public Dialogue nextDialogue;
        public Scenario Scenario { get; set; }
        
        private readonly List<Component> _components = new List<Component>();

        protected Dialogue(SceneUnitType type, Scenario scenario): base(type)
        {
            Scenario = scenario;
        }

        private void UpdateDialogues(Dialogue dialogue)
        {
            nextDialogue = dialogue;
            EditorUtility.SetDirty(Scenario);
            EditorUtility.SetDirty(this);
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
            EditorUtility.SetDirty(this);
        }


        public void AddNext(Dialogue dialogue)
        {
            UpdateDialogues(dialogue);
        }

        public void RemoveNext()
        {
            UpdateDialogues(null);
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