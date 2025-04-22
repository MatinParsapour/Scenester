using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Entity.Base;

namespace Dastan.Scenester.Editor.Entity.Base
{
    public abstract class Component : SceneUnit
    {

        public Dialogue Dialogue { get; set; }
        
        protected Component(Dialogue dialogue, SceneUnitType type) : base(type)
        {
            Dialogue = dialogue;
        }

        public abstract Component Execute();
    }
}