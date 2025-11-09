using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    [CreateAssetMenu(fileName = "UniqueIdSettings", menuName = "UniqueId/Create UniqueId Settings")]
    public class UniqueIdSettings : ScriptableObject
    {
        [field: SerializeField] public List<IdSettingsEntry> IdEntries { get; private set; } = new();
        
        [ContextMenu("Refresh Id Entries")]
        public void RefreshIdEntries()
        {
            var previousEntries = IdEntries;
            IdEntries = new List<IdSettingsEntry>();
            var types = TypeUtils.GetDerivedTypesFrom<UniqueId>();
            foreach (var type in types)
            {
                var previousEntry = previousEntries.Find(e => e.typeName == type.FullName);
                var entry = new IdSettingsEntry
                {
                    typeName = type.Name,
                    fullTypeName = type.FullName,
                    overridesCodeGenDestination = previousEntry is { overridesCodeGenDestination: true },
                    memberDefinitionDestinationPath = previousEntry is { overridesCodeGenDestination: true } ? 
                        previousEntry.memberDefinitionDestinationPath : 
                        string.Empty,
                };
                IdEntries.Add(entry);
            }
        }

        public IdSettingsEntry GetSettingsForType(string typeName)
        {
            foreach (var entry in IdEntries)
            {
                if (entry.typeName == typeName)
                {
                    return entry;
                }
            }
            
            return null;
        }
        
        public static UniqueIdSettings GetIdSettings()
        {
            var idSettings = AssetDatabase.FindAssets($"t:UniqueIdSettings", new []{ "Assets" })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<UniqueIdSettings>);

            if (idSettings.Count() != 1)
            {
                Debug.LogError($"Expecting exactly one CarambaIdSettings asset, found {idSettings.Count()}");
            }
            
            return idSettings.First();
        }
    }

    [Serializable]
    public class IdSettingsEntry
    {
        [ReadOnly] public string typeName = string.Empty;
        [HideInInspector] public string fullTypeName = string.Empty;
        public bool overridesCodeGenDestination = false;
        [FolderPath, ShowIf("overridesCodeGenDestination")] public string memberDefinitionDestinationPath = string.Empty;
    }
}