using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Entity.Base;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public class EntryDialogue : Dialogue
    {
        public EntryDialogue(Scenario scenario) : base(SceneUnitType.Entry, scenario)
        {
        }

        public override Dialogue Execute()
        {
            return nextDialogue;
        }
    }
}