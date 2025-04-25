using System.Collections.Generic;
using Dastan.Scenester.Editor.Enumeration;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public abstract class Dialogue : SceneUnit
    {
        [HideInInspector]
        [SerializeField]
        public List<Dialogue> nextDialogues = new();

        [HideInInspector]
        [SerializeField]
        public List<Component> components = new();
        public Vector2 Position { get; set; }
        
        [SerializeField]
        public Scenario Scenario { get; set; }

        private void OnEnable()
        {
            nextDialogues = new List<Dialogue>();
            components = new List<Component>();
        }

        protected Dialogue(SceneUnitType type, Scenario scenario): base(type)
        {
            Scenario = scenario;
        }

        private void UpdateList<T>(T unit, List<T> list, bool add) where T : SceneUnit
        {
            if (add)
            {
                list.Add(unit);
            }
            else
            {
                list.Remove(unit);
            }
            
            EditorUtility.SetDirty(Scenario);
            EditorUtility.SetDirty(this);
            
        }

        private void UpdateDialogues(Dialogue next, bool add)
        {
            UpdateList(next, nextDialogues, add);
        }

        private void UpdateComponents(Component component, bool add)
        {
            UpdateList(component, components, add);
        }


        public void AddNext(Dialogue next)
        {
            UpdateDialogues(next, true);
        }

        public void RemoveNext(Dialogue next)
        {
            UpdateDialogues(next, false);
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