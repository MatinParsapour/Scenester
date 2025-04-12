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

        protected Dialogue(SceneUnitType type, Scenario scenario): base(type)
        {
            Scenario = scenario;
        }

        private void UpdateDialogues(Dialogue dialogue)
        {
            nextDialogue = dialogue;
            EditorUtility.SetDirty(Scenario);
        }

        public void AddNext(Dialogue dialogue)
        {
            UpdateDialogues(dialogue);
        }

        public void RemoveNext()
        {
            UpdateDialogues(null);
        }
        
        public abstract Dialogue Execute();
    }
}