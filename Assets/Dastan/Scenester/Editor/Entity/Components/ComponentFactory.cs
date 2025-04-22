using System.Collections.Generic;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Enumeration;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Components
{
    public class ComponentFactory
    {

        private static T CreateComponent<T>(Dialogue dialogue, SceneUnitType type) where T : Base.Component
        {
            T component = ScriptableObject.CreateInstance<T>();
            component.Dialogue = dialogue;
            component.type = type;
            return component;
        }
        
        public static AudioComponent CreateAudioComponent(Dialogue dialogue)
        {
            return CreateComponent<AudioComponent>(dialogue, SceneUnitType.Audio);
        }

        public static SubtitleComponent CreateSubtitleComponent(Dialogue dialogue)
        {
            return CreateComponent<SubtitleComponent>(dialogue, SceneUnitType.Subtitle);
        }

        public static List<Base.Component> CreateComponents(Dialogue dialogue)
        {
            return new List<Base.Component>()
            {
                CreateAudioComponent(dialogue),
                CreateSubtitleComponent(dialogue)
            };
        }
        
    }
}