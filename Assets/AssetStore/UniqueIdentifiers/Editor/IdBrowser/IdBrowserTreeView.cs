using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;

namespace UniqueIdentifier.Editor
{
    internal class IdBrowserTreeView : TreeView
    {
        public event Action<IdBrowserTreeViewItem> ItemClicked;

        public int ItemCount { get; private set; }

        public IdBrowserTreeView(TreeViewState state) : base(state) => Initialize();

        public IdBrowserTreeView(TreeViewState state, MultiColumnHeader multiColumnHeader) : base(state, multiColumnHeader) => Initialize();

        private void Initialize()
        {
            showAlternatingRowBackgrounds = true;
        }

        protected override TreeViewItem BuildRoot()
        {
            var root = new TreeViewItem(0, -1);
            
            ItemCount = 0;
            var id = 1;
            var derivedTypes = TypeUtils.GetDerivedTypesFrom<UniqueId>();
            foreach (var type in derivedTypes)
            {
                root.AddChild(new IdBrowserTreeViewItem(id++, 0, type));
                ++ItemCount;
            }
            
            return root;
        }

        protected override bool CanMultiSelect(TreeViewItem item) => false;

        protected override void SelectionChanged(IList<int> selectedIds)
        {
            if (selectedIds.Count != 1)
            {
                return;
            }
            
            OnItemClicked(selectedIds[0]);
        }

        protected override void SingleClickedItem(int id) => OnItemClicked(id);

        private void OnItemClicked(int itemId)
        {
            var item = FindItem(itemId, rootItem);
            if (item is IdBrowserTreeViewItem treeViewItem)
            {
                ItemClicked?.Invoke(treeViewItem);
            }
        }
    }
    
    internal class IdBrowserTreeViewItem : TreeViewItem
    {
        public Type IdType { get; }
        
        public IdBrowserTreeViewItem(int id, int depth, Type type) : base(id, depth, type.Name) => IdType = type;
    }
}