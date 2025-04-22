using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;
using Component = Dastan.Scenester.Editor.Entity.Base.Component;

namespace Dastan.Scenester.Editor.Entity.Components
{
    public class AudioComponent : Component
    {

        public AudioSource audioSource;
        public AudioClip audioClip;
        
        public AudioComponent(Dialogue dialogue) : base(dialogue,SceneUnitType.Audio)
        {
        }

        public override Component Execute()
        {
            audioSource.PlayOneShot(audioClip);
            return this;
        }
    }
}