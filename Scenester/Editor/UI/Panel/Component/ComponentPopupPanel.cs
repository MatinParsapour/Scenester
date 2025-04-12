using System;
using System.Collections.Generic;
using System.Linq;
using Dastan.Scenester.Editor.Entity.Base;
using Dastan.Scenester.Editor.util;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Dastan.Scenester.Editor.UI.Panel.Component
{
    public class ComponentPopupPanel : EditorWindow
    {

        private static Dialogue _dialogue;
        private VisualElement _root;
        private List<Entity.Base.Component> _components;

        public static void Show(Rect rect, Dialogue dialogue)
        {
            _dialogue = dialogue;
            
            ComponentPopupPanel window = CreateInstance<ComponentPopupPanel>();
            Vector2 screenPos = new Vector2(rect.x + rect.width, rect.y);
            Rect popupRect = new Rect(screenPos, new Vector2(rect.width, 365));
            window.ShowAsDropDown(popupRect, popupRect.size);
        }

        private void CreateGUI()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Dastan/Scenester/Editor/UI/Styles/ComponentPopup.uxml");
            _root = visualTree.CloneTree();
            rootVisualElement.Add(_root);
            
            PopulateComponents();
        }

        private void PopulateComponents()
        {
            var componentsScrollView = _root.Q<ScrollView>("ComponentsListScrollView");

            _components = ComponentUtil.GetComponents(_dialogue);

            foreach (Entity.Base.Component component in _components)
            {
                Button button = new Button(() =>
                {
                    _dialogue.AddComponent(component);
                    Close();
                })
                {
                    text = $"{component.type.ToString()}"
                };

                componentsScrollView.Add(button);
            }
        }
    }
}