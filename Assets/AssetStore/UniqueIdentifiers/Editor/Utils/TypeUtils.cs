using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace UniqueIdentifier.Editor
{
    internal readonly struct TypeInfo
    {
        public readonly string Name;
        public readonly string ClassNamespace;
        public readonly string FilePath;
        public readonly List<FieldInfo> Fields;
        
        public TypeInfo(string name, string classNamespace, string filePath, List<FieldInfo> fields)
        {
            Name = name;
            ClassNamespace = classNamespace;
            FilePath = filePath;
            Fields = fields;
        }
    }
    
    internal static class TypeUtils
    {
        public static List<Type> GetDerivedTypesFrom<T>() where T : class
        {
            var baseType = typeof(T);
            return TypeCache.GetTypesDerivedFrom<T>()
                .Where(type => type.IsClass && !type.IsAbstract && baseType.IsAssignableFrom(type))
                .ToList();
        }
        
        public static TypeInfo GetTypeInfo(Type type)
        {
            var fields = type.GetFields()
                .Where(f => f.IsPublic && f.IsStatic && f.FieldType == type)
                .ToList();
            
            return new TypeInfo(type.Name, type.Namespace, GetScriptFilePath(type), fields);
        }

        public static string GetScriptFilePath(Type type)
        {
            var script = AssetDatabase.FindAssets($"t:MonoScript {type.Name}", new []{ "Assets/Scripts" })
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<MonoScript>)
                .FirstOrDefault(s => s != null && s.GetClass() == type);

            return script != null ? AssetDatabase.GetAssetPath(script) : "Not Found";
        }
    }
}