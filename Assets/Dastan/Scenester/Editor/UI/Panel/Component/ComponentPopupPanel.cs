using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.Entity.Components;
using Dastan.Scenester.Editor.UI.Panel.ScenePanel;
using Dastan.Scenester.Editor.util;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Dastan.Scenester.Editor.UI.Panel.Component
{

    public class ComponentPopupPanel : ScriptableObject, ISearchWindowProvider
    {

        public Dialogue dialogue;
        public Action<Entity.Base.Component> OnComponentSelected;
        
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> tree = new List<SearchTreeEntry>();

            tree.Add(new SearchTreeGroupEntry(new GUIContent("Components")));

            tree.Add(new SearchTreeGroupEntry(new GUIContent("Action Components"), 1));
            tree.Add(new SearchTreeEntry(new GUIContent("Audio Component")) { level = 2, userData = ComponentFactory.CreateAudioComponent(dialogue) });
            tree.Add(new SearchTreeEntry(new GUIContent("Subtitle Component")) { level = 2, userData = ComponentFactory.CreateSubtitleComponent(dialogue) });

            tree.Add(new SearchTreeGroupEntry(new GUIContent("Conditional Components"), 1));
            
            return tree;
        }

        public bool OnSelectEntry(SearchTreeEntry entry, SearchWindowContext context)
        {

            Entity.Base.Component component = entry.userData as Entity.Base.Component;
            if (!ReferenceEquals(component, null))
            {
                dialogue.AddComponent(component);
                component.Dialogue = dialogue;
                
                OnComponentSelected?.Invoke(component);
            }
            return true;
        }
    }
    
}