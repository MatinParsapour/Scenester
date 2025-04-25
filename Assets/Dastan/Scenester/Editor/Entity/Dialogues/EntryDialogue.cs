using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public class EntryDialogue : Dialogue
    {
        public EntryDialogue(Scenario scenario) : base(SceneUnitType.Entry, scenario)
        {
        }

        public override Dialogue Execute()
        {
            Debug.Log(nextDialogues);
            foreach (Dialogue dialogue in nextDialogues)
            {
                dialogue.Execute();
            }
            return this;
        }
    }
}