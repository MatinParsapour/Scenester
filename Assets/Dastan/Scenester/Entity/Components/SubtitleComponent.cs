using System.ComponentModel;
using UnityEngine;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using TMPro;
using Unity.VisualScripting;
using Component = Dastan.Scenester.Editor.Entity.Base.Component;

namespace Dastan.Scenester.Editor.Entity.Components
{
    public class SubtitleComponent : Component
    {
        
        [Tooltip("The text you want to display"), SerializeField]
        public string text;
        
        [Tooltip("The subtitle object (TextMeshPro)"), SerializeField]
        public TextMeshProUGUI display; 
        
        public SubtitleComponent(Dialogue dialogue) : base(dialogue, SceneUnitType.Subtitle)
        {
        }

        public override Component Execute()
        {
            Debug.Log(display.text);
            display.text = text;
            Debug.Log(display.text);
            return this;
        }
    }
}