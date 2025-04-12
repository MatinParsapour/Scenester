using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.UI.Inspector;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dastan.Scenester.Editor.UI.SceneDirector.Core
{
    public abstract class DialogueUI : Node
    {
        private readonly Dialogue _dialogue;

        public Dialogue Dialogue => _dialogue;
        
        protected DialogueUI(Dialogue dialogue)
        {
            _dialogue = dialogue;
            title = _dialogue.type.ToString();
        }

        public override void OnSelected()
        {
            SceneUnitInspector.GetInstance(_dialogue).ChangeInspector();
        }
    }
}