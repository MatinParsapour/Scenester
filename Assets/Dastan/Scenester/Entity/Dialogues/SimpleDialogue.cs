using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Dialogues
{
    public class SimpleDialogue : Dialogue
    {
        public SimpleDialogue(Scenario scenario) : base(SceneUnitType.SimpleDialogue, scenario)
        {
        }

        public override Dialogue Execute()
        {
            Debug.Log("Components : " + components.Count);
            foreach (Base.Component component in components)
            {
                Debug.Log("Running Component : " + component.name);
                component.Execute();
            }
            
            foreach (Dialogue dialogue in nextDialogues)
            {
                dialogue.Execute();
            }
            return this;
        }
    }
}