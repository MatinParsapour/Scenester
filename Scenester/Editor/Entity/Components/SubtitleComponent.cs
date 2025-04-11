using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;

namespace Dastan.Scenester.Editor.Entity.Components
{
    public class SubtitleComponent : Component
    {
        public SubtitleComponent(Dialogue dialogue) : base(dialogue, SceneUnitType.Subtitle)
        {
        }

        public override Component Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}