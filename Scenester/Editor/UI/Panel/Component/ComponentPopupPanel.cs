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
            VisualElement root = visualTree.CloneTree();
            rootVisualElement.Add(root);
            
            PopulateComponents(root);
        }

        private static void PopulateComponents(VisualElement root)
        {
            var scrollView = root.Q<ScrollView>("ComponentsListScrollView");

            List<Entity.Base.Component> components = ComponentUtil.GetComponents(_dialogue);

            foreach (Entity.Base.Component component in components)
            {
                Button button = new Button(() => Debug.Log($"Button {component.type.ToString()} clicked"))
                {
                    text = $"{component.type.ToString()}"
                };

                scrollView.Add(button);
            }
        }
    }
}