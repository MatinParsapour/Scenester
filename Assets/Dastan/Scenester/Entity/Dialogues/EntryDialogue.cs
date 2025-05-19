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
            Debug.Log("Entry Dialogue Next Dialogue : " + nextDialogues.Count);
            foreach (Dialogue dialogue in nextDialogues)
            {
                Debug.Log("Running Dialogue : " + dialogue.name);
                dialogue.Execute();
            }
            return this;
        }
    }
}