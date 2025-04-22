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
            foreach (Base.Component component in components)
            {
                component.Execute();
            }
            return nextDialogue?.Execute();
        }
    }
}