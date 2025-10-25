using System;
using System.Linq;
using Sirenix.OdinInspector;
using UIFramework;
using UnityEngine;

namespace QuitCut.NavBar
{
    
    [Serializable]
    public class NavBarItemData
    {
        public string name;
        public Sprite icon;
    
        [ValueDropdown(nameof(GetUIViewTypeNames))]
        public string typeName;
    
        public Type Type => string.IsNullOrEmpty(typeName) ? null : Type.GetType(typeName);
    
        public static System.Collections.Generic.IEnumerable<string> GetUIViewTypeNames()
        {
            var baseType = typeof(UIScreenBase);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.AssemblyQualifiedName);
        }
    }
    
    [CreateAssetMenu(fileName = "NavBarSettings", menuName = "QuitCut/NavBar/Settings", order = 0)]
    public class NavBarSettings : ScriptableObject
    {
        public NavBarItemData[] Items;
    }
}