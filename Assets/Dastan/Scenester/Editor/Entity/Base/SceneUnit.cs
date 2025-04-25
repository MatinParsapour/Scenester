using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Base
{
    [System.Serializable]
    public abstract class SceneUnit : ScriptableObject
    {

        [SerializeField]
        private readonly string _id = System.Guid.NewGuid() + "_" + System.Guid.NewGuid();
        
        [SerializeField] public SceneUnitType type;
        [SerializeField] public string key;
        [HideInInspector] [SerializeField] public bool isNew;

        public string ID => _id;

        protected SceneUnit(SceneUnitType type)
        {
            this.type = type;
        }
    };
}