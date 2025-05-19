using System.Collections.Generic;
using UnityEngine;

namespace Dastan.Scenester.ReferenceManagement
{
    public class ScenesterObjectManager
    {
        private static readonly Dictionary<string, GameObject> Lookup = new Dictionary<string, GameObject>();
        private static bool isInitialized = false;


        private static void Initialize()
        {
            if (isInitialized) return;
            
            Lookup.Clear();
            
            ScenesterObject[] objects = Object.FindObjectsOfType<ScenesterObject>();
            foreach (ScenesterObject scenesterObject in objects)
            {
                if (Lookup.ContainsKey(scenesterObject.ID))
                {
                    continue;
                }
                
                Lookup[scenesterObject.ID] = scenesterObject.gameObject;
            }
            
            isInitialized = true;
        }

        public static void GetScenesterObject(string id, out GameObject value)
        {
            Initialize();
            Lookup.TryGetValue(id, out value);
        }

    }
}