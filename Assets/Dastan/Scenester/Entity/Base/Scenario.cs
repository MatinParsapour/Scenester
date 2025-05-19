using System.Collections.Generic;
using Dastan.Scenester.Editor.Enumeration;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Base
{
    [System.Serializable]
    public class Scenario : SceneUnit
    {

        public Scenario() : base(SceneUnitType.Scenario)
        {
            
        }

        [HideInInspector]
        [SerializeField]
        public EntryDialogue entryDialogue;
        private readonly List<Dialogue> _dialogues = new List<Dialogue>();


        private void UpdateDialogues(Dialogue dialogue, bool add)
        {
            if (add)
            {
                _dialogues.Add(dialogue);
            }
            else
            {
                _dialogues.Remove(dialogue);
            }
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
        

        public void AddDialogue(Dialogue dialogue)
        {
            UpdateDialogues(dialogue, true);
        }

        public void RemoveDialogue(Dialogue dialogue)
        {
            UpdateDialogues(dialogue, false);
        }

        public List<Dialogue> GetDialogues()
        {
            return _dialogues;
        }


        public void Play()
        {
            
            entryDialogue.Execute();
        }
        
    }
}