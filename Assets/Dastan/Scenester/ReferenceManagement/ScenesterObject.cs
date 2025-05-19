using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dastan.Scenester.ReferenceManagement
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    public class ScenesterObject : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private string id;

        public string ID => id;

#if UNITY_EDITOR
        private void Awake()
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }
        }

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
            }
        }

#endif
    }
}