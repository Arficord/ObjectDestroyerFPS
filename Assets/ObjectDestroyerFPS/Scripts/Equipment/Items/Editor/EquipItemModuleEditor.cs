using System;
using System.Collections;
using System.Collections.Generic;
using Arf.ReflectionUtils;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

namespace ObjectDestroyerFPS.Equipment.Items.Modules.InspectorEditor
{
    [CustomPropertyDrawer(typeof(EquipItemModule))]
    public class EquipItemModuleEditor : PropertyDrawer
    {
        private const float OptionBarHeight = 20;

        private SerializedProperty _property;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _property = property;
            if (GUI.Button(new Rect(position.xMin, position.yMax - 20f, position.width, OptionBarHeight), "Select Module"))
            {
                OnChangeModuleButtonClick();
            }
            EditorGUI.PropertyField(position, property, label, true);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property) + OptionBarHeight;
        }

        private void OnChangeModuleButtonClick()
        {
            var menu = new GenericMenu();
            
            Type type = fieldInfo.FieldType;
            foreach (var moduleType in Reflection.GetAllInheritedClasses(type))
            {
                menu.AddItem(new GUIContent($"Module/{moduleType.Name}"), 
                    false, OnModuleChangeRequest, 
                    moduleType);
            }
                
            menu.ShowAsContext();
        }
        
        private void OnModuleChangeRequest(object target)
        {
            var module = Activator.CreateInstance((Type)target);
            _property.managedReferenceValue = module;
            _property.serializedObject.ApplyModifiedProperties();
        }
    }
}