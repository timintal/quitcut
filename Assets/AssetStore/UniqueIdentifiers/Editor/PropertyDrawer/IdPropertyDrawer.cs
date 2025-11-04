using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    [CustomPropertyDrawer(typeof(UniqueId), true)]
    public class IdPropertyDrawer : PropertyDrawer
    {
        private bool initialized;
        private Type currentItemType;
        private object currentObject;
        
        private static readonly IdReflectionCache ReflectionCache = new();
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!GetPropertyType(property, out var type)) { return; }
            ReflectionCache.RefreshType(type);
            
            var selectedIndex = ReflectionCache.GetTypeIndexByValue(type, property.boxedValue);
            if (selectedIndex == -1)
            {
                // In case the value coming from the serialized property is not found in the list of fields, we just assign the first one
                // (like what would happen if it was an enum)
                selectedIndex = 0;
                property.boxedValue = Convert.ChangeType(ReflectionCache.GetValueForType(type, selectedIndex), type);
                property.serializedObject.ApplyModifiedProperties();
            }
            
            var displayName = ReflectionCache.GetFieldNamesForType(type)[selectedIndex];
            EditorGUI.BeginProperty(position, label, property);
            
            position = EditorGUI.PrefixLabel(position, label);
            if (GUI.Button(position, displayName, EditorStyles.popup))
            {
                var dropdown = new IdAdvancedDropdown(new AdvancedDropdownState(), type, (newSelectedIndex) =>
                {
                    property.boxedValue = Convert.ChangeType(ReflectionCache.GetValueForType(type, newSelectedIndex), type);
                    property.serializedObject.ApplyModifiedProperties();
                });

                dropdown.Show(position);
            }
            
            EditorGUI.EndProperty();
        }
        
        private bool GetPropertyType(SerializedProperty property, out Type type)
        {
            type = null;

            if (property == null)
            {
                return false;
            }

            // Try using fieldInfo (works when it's a direct field)
            if (fieldInfo != null)
            {
                type = fieldInfo.FieldType;

                // If it's a list, extract the element type
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                {
                    type = type.GetGenericArguments()[0];
                }
                else if (type.IsArray)
                {
                    type = type.GetElementType();
                }
                return true;
            }

            // If fieldInfo is null, try extracting type from propertyPath
            var parentProperty = property.serializedObject.FindProperty(property.propertyPath.Split('.')[0]);
            if (parentProperty != null)
            {
                type = GetSerializedPropertyTargetType(parentProperty);
                return type != null;
            }

            return false;
        }

        private Type GetSerializedPropertyTargetType(SerializedProperty property)
        {
            // Get the type of the serialized object (the class containing this property)
            var targetObject = property.serializedObject.targetObject;

            if (targetObject == null)
            {
                return null;
            }

            // Find the property in the actual class/struct
            var type = targetObject.GetType();
            var field = type.GetField(property.name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            return field?.FieldType;
        }

        
    }
}