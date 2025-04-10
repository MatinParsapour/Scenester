using Dastan.Scenester.Editor.Entity.Attribute;
using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;

namespace Dastan.Scenester.Entity.Base
{
    [System.Serializable]
    public abstract class SceneUnit : ScriptableObject
    {

        private readonly string _id = System.Guid.NewGuid() + "_" + System.Guid.NewGuid();
        
        [SerializeField] [ReadOnly] public SceneUnitType type;
        [SerializeField] public string key;

        public string ID => _id;

        protected SceneUnit(SceneUnitType type)
        {
            this.type = type;
        }
    };
}