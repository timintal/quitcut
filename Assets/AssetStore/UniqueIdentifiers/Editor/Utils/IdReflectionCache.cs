using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    internal class IdReflectionCache
    {
        private readonly Dictionary<Type, List<FieldInfo>> typeFieldsCache = new();

        public void RefreshType(Type type)
        {
            if (!typeFieldsCache.TryGetValue(type, out var fields))
            {
                fields = new List<FieldInfo>();
                typeFieldsCache.Add(type, fields);
            }
            fields.Clear();

            var typeInfo = TypeUtils.GetTypeInfo(type);
            fields.AddRange(typeInfo.Fields);
        }
        
        public List<string> GetFieldNamesForType(Type type)
        {
            var fields = GetFieldsForType(type);
            return fields.Select(f => f.Name).ToList();
        }
        
        public int GetTypeIndexByValue(Type type, object value)
        {
            if (value is UniqueId uniqueId && uniqueId.Guid == LongGuid.None)
            {
                return -1;
            }
            
            var targetValue = Convert.ChangeType(value, type);
            if (targetValue == null)
            {
                return -1;
            }
            
            var fields = GetFieldsForType(type);
            if (fields == null || fields.Count == 0)
            {
                Debug.LogError($"There are no declared fields for type {type}");
                return -1;
            }

            for (var i = 0; i < fields.Count; ++i)
            {
                var fieldValue = Convert.ChangeType(fields[i].GetValue(null), type);
                if (fieldValue.Equals(targetValue))
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        public object GetValueForType(Type type, int index)
        {
            var fields = GetFieldsForType(type);
            if (index < 0 || index >= fields.Count)
            {
                return null;
            }

            return fields[index].GetValue(null);
        }
        
        private List<FieldInfo> GetFieldsForType(Type type)
        {
            if (typeFieldsCache.TryGetValue(type, out var fields))
            {
                return fields;
            }
            fields = new List<FieldInfo>();
            typeFieldsCache.Add(type, fields);
            return fields;
        }
    }
}