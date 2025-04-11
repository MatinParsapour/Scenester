using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;

namespace Dastan.Scenester.Editor.Entity.Components
{
    public class AudioComponent : Component
    {
        public AudioComponent(Dialogue dialogue) : base(dialogue,SceneUnitType.Audio)
        {
        }

        public override Component Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}