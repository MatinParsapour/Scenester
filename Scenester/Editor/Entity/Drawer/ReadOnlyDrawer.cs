using System;
using System.Reflection;
using Dastan.Scenester.Editor.Entity.Attribute;
using UnityEditor;
using UnityEngine;

namespace Dastan.Scenester.Editor.Entity.Drawer
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            // EditorGUI.EnumPopup(position, label, Enum.ToObject(property.enumType, property.enumValueIndex));
            GUI.enabled = true;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}