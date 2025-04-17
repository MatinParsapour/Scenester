using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Dastan.Scenester.Editor.Enumeration;
using Dastan.Scenester.Entity.Base;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;

namespace Dastan.Scenester.Editor.Entity.Base
{
    [System.Serializable]
    public class Scenario : SceneUnit
    {

        public Scenario() : base(SceneUnitType.Scenario)
        {
            
        }

        [HideInInspector]
        public EntryDialogue entryDialogue;
        private readonly Dictionary<Dialogue, Vector2> _dialogues = new Dictionary<Dialogue, Vector2>();


        private void UpdateDialogues(Dialogue dialogue, Vector2 position, bool add)
        {
            if (add)
            {
                _dialogues.Add(dialogue, position);
            }
            else
            {
                _dialogues.Remove(dialogue);
            }
            
            EditorUtility.SetDirty(this);
        }
        

        public void AddDialogue(Dialogue dialogue, Vector2 position)
        {
            UpdateDialogues(dialogue, position, true);
        }

        public void RemoveDialogue(Dialogue dialogue)
        {
            UpdateDialogues(dialogue, Vector2.zero, false);
        }

        public Dictionary<Dialogue, Vector2> GetDialogues()
        {
            return _dialogues;
        }


        public void Play()
        {
            entryDialogue.Execute();
        }
        
    }
}