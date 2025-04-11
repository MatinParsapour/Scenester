using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Entity.Base;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public abstract class Component : SceneUnit
    {
        protected Component(SceneUnitType type) : base(type)
        {
        }
    }
}