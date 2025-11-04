using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    public class IdInspector
    {
        private Type selectedType;
        private TypeInfo selectedTypeInfo;
        private ReorderableList reorderableList;
        private readonly List<IdEntry> idEntries = new();

        public void SetType(Type type)
        {
            selectedType = type;
            LoadIdEntries();
            SetupReorderableList();
        }
        
        public void Draw(Rect rect)
        {
            GUILayout.BeginArea(rect);

            if (selectedType == null)
            {
                EditorGUILayout.LabelField("No type selected.", EditorStyles.helpBox);
                GUILayout.EndArea();
                return;
            }

            reorderableList?.DoLayoutList();
            
            EditorGUILayout.Space();

            if (GUILayout.Button("Apply Changes"))
            {
                OnApplyChanges();
            }
            
            GUILayout.EndArea();
        }
        
        private void LoadIdEntries()
        {
            idEntries.Clear();
            if (selectedType == null)
            {
                return;
            }

            selectedTypeInfo = TypeUtils.GetTypeInfo(selectedType);
            foreach (var field in selectedTypeInfo.Fields)
            {
                var uniqueId = field.GetValue(null) as UniqueId;
                if (uniqueId == null)
                {
                    continue;
                }
                
                idEntries.Add(new IdEntry
                {
                    FieldName = field.Name,
                    Guid = uniqueId.Guid
                });
            }
        }

        private void SetupReorderableList()
        {
            reorderableList = new ReorderableList(
                idEntries, 
                typeof(IdEntry), 
                false, 
                true, 
                true, 
                true)
            {
                drawHeaderCallback = DrawListHeader,
                drawElementCallback = DrawListElement,
                onAddCallback = AddListElement,
                onRemoveCallback = RemoveListElement
            };
        }
        
        private void DrawListHeader(Rect rect) => EditorGUI.LabelField(rect, $"{selectedTypeInfo.Name}");
        
        private void DrawListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (index < 0 || index >= idEntries.Count)
            {
                return;
            }

            var field = idEntries[index];
            var halfWidth = (rect.width - 10) / 2;

            field.FieldName = EditorGUI.TextField(new Rect(rect.x, rect.y + 2, halfWidth, EditorGUIUtility.singleLineHeight), field.FieldName);
            EditorGUI.LabelField(new Rect(rect.x + halfWidth + 5, rect.y + 2, halfWidth, EditorGUIUtility.singleLineHeight), field.Guid.ToString());
        }
        
        private void AddListElement(ReorderableList list) => idEntries.Add(new IdEntry
        {
            FieldName = $"New{selectedTypeInfo.Name}", 
            Guid = LongGuid.NewGuid() 
        });
        
        private void RemoveListElement(ReorderableList list)
        {
            if (list.index >= 0 && list.index < idEntries.Count)
            {
                idEntries.RemoveAt(list.index);
            }
        }

        private void OnApplyChanges()
        {
            var targetDirectory = CodeGenerator.GetClassDefinitionDirectoryPath(selectedTypeInfo.FilePath);
            
            var uniqueIdSettings = UniqueIdSettings.GetIdSettings();
            var settingsEntry = uniqueIdSettings.GetSettingsForType(selectedTypeInfo.Name);
            if (settingsEntry != null)
            {
                if (settingsEntry.overridesCodeGenDestination)
                {
                    targetDirectory = settingsEntry.memberDefinitionDestinationPath;
                }
            }
            
            CodeGenerator.GenerateIdEntriesPartialClass(
                selectedTypeInfo.FilePath,
                targetDirectory,
                selectedTypeInfo.ClassNamespace,
                selectedTypeInfo.Name,
                idEntries);
            
            AssetDatabase.ImportAsset(selectedTypeInfo.FilePath);
        }
    }

    internal class IdEntry
    {
        public string FieldName;
        public LongGuid Guid;
    }
}
