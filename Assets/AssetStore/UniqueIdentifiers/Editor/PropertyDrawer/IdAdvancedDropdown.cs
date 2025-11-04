using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;

namespace UniqueIdentifier.Editor
{
    public class IdAdvancedDropdown : AdvancedDropdown
    {
        private readonly Type type;
        private readonly Action<int> onItemSelected;
        private static readonly IdReflectionCache ReflectionCache = new();
        
        public IdAdvancedDropdown(AdvancedDropdownState state, Type type, Action<int> onItemSelected)
            : base(state)
        {
            this.type = type;
            this.onItemSelected = onItemSelected;
            ReflectionCache.RefreshType(type);
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            AdvancedDropdownItem root = new AdvancedDropdownItem(type.Name);
            List<string> fieldNames = ReflectionCache.GetFieldNamesForType(type);

            for (int i = 0; i < fieldNames.Count; i++)
            {
                root.AddChild(new DropdownItem(fieldNames[i], i));
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            if (item is DropdownItem dropdownItem)
            {
                onItemSelected?.Invoke(dropdownItem.Index);
            }
        }

        private class DropdownItem : AdvancedDropdownItem
        {
            public int Index { get; }

            public DropdownItem(string name, int index) : base(name) => Index = index;
        }
    }
}