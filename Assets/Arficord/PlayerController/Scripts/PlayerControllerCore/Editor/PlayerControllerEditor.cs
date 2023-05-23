using System;
using Arf.Player.Abilities;
using Arf.ReflectionUtils;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Arf.Player.InspectorEditor
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor 
    {
        private ReorderableList _list;

        private SerializedProperty _selectedAbility;

        private GUIStyle _errorStyle;
        private GUIStyle _activeAbilityStyle;

        private void OnEnable()
        {
            InitializeList();
        }
        
        #region Initialization
        private void InitializeList()
        {
            _list = new ReorderableList(serializedObject,
                serializedObject.FindProperty("_abilities"),
                true, true, true, true)
            {
                drawElementCallback = AbilitiesListDrawElementCallback,
                drawHeaderCallback = AbilitiesListDrawHeaderCallback,
                onAddDropdownCallback = AbilitiesListOnAddDropdownCallback,
                onSelectCallback = AbilitiesListOnSelectCallback,
                onRemoveCallback = AbilitiesListOnRemoveCallback
            };

        }
        
        private void InitializeStyles()
        {
            _errorStyle = new GUIStyle(EditorStyles.textField)
            {
                normal = {textColor = Color.red}
            };
            
            _activeAbilityStyle = new GUIStyle(EditorStyles.textField)
            {
                normal = {textColor = new Color(0.2f, 0.8f, 0.1f)}
            };
        }
        #endregion
        
        public override void OnInspectorGUI()
        {
            if (_list == null)
            {
                InitializeList();
                return;
            }
            
            InitializeStyles();
            serializedObject.Update();

            DrawDefaultElements();
            EditorGUILayout.Space(10);
            _list.DoLayoutList();

            DrawSelectedAbilityInfo();
            
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawDefaultElements()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("characterLocomotion"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("characterAnimator"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("cameraController"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("walkSpeed"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("runSpeed"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("gravity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("onGroundYVelocity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("colideChecker"));
        }

        private void DrawSelectedAbilityInfo()
        {
            if (_selectedAbility == null)
            {
                return;
            }

            var selectedAbilityRef = (Ability) _selectedAbility.managedReferenceValue;
            EditorGUILayout.PropertyField(_selectedAbility, new GUIContent(selectedAbilityRef.GetType().Name), true);
        }

        #region AbilitiesList
        private void AbilitiesListDrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Abilities");
        }

        private void AbilitiesListOnSelectCallback(ReorderableList list)
        {
            _selectedAbility = list.serializedProperty.GetArrayElementAtIndex(list.index);
        }

        private void AbilitiesListOnRemoveCallback(ReorderableList list)
        {
            if (_selectedAbility == null)
            {
                Debug.LogError("Tried to remove ability, but no ability selected.");
                return;
            }
            
            var arraySize = _list.serializedProperty.arraySize;

            int deleteItemIndex = -1;
            
            for (int index = 0; index < arraySize; index++)
            {
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                if (element.managedReferenceValue == _selectedAbility.managedReferenceValue)
                {
                    deleteItemIndex = index;
                    break;
                }
            }

            if (deleteItemIndex == -1)
            {
                Debug.LogError($"Tried to delete Ability [{_selectedAbility.displayName}] but cannot find it in abilities list.");
                return;
            }
            
            list.serializedProperty.DeleteArrayElementAtIndex(deleteItemIndex);
            serializedObject.ApplyModifiedProperties();

            _selectedAbility = null;
        }
        
        private void AbilitiesListOnAddDropdownCallback(Rect rect, ReorderableList list)
        {
            var menu = new GenericMenu();

            foreach (var abilityType in Reflection.GetAllInheritedClasses<Ability>())
            {
                menu.AddItem(new GUIContent($"Ability/{abilityType.Name}"), 
                    false, OnAbilitiesAddClick, 
                    abilityType);
            }
                
            menu.ShowAsContext();
        }
        
        private void AbilitiesListDrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);

            var ability = (Ability)element.managedReferenceValue;
            if (ability == null)
            {
                EditorGUI.LabelField(new Rect(rect.x + 10, rect.y + 2, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), "Error. Ability is null!", _errorStyle);
                return;
            }
            
            var abilityName = ability.GetType().Name;
            if (ability.Active)
            {
                EditorGUI.LabelField(new Rect(rect.x, rect.y + 2, 15, EditorGUIUtility.singleLineHeight), "A", _activeAbilityStyle);
            }
            EditorGUI.LabelField(new Rect(rect.x + 15, rect.y + 2, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), abilityName);
        }
        
        private void OnAbilitiesAddClick(object target)
        {
            var ability = Activator.CreateInstance((Type)target);
            var index = _list.serializedProperty.arraySize;
            _list.serializedProperty.arraySize++;
            _list.index = index;
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);
            element.managedReferenceValue = ability;
            serializedObject.ApplyModifiedProperties();
        }
        #endregion
    }
}
