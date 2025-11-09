using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UniqueIdentifier.Editor
{
    public class IdBorwser : EditorWindow
    {
        [MenuItem("Tools/Unique Id/Id Browser")]
        private static void Init()
        {
            var wnd = GetWindow<IdBorwser>();
            wnd.titleContent = new GUIContent("Id Browser");
            wnd.Show();
        }

        private const float DividerMinimum = 0.2f;
        private const float DividerMaximum = 0.8f;

        private IdBrowserTreeView treeView;
        private TreeViewState treeViewState;
        private Vector2 scrollPosition;
        private int separatorPosition = 250;
        private bool isDragging;
        private bool viewSettings;
        
        private readonly IdInspector idInspector = new();

        private void OnEnable()
        {
            treeViewState ??= new TreeViewState();
            treeView = new IdBrowserTreeView(treeViewState);
            treeView.ItemClicked += OnItemClicked;
        }

        private void OnItemClicked(IdBrowserTreeViewItem item)
        {
            idInspector.SetType(item.IdType);
        }

        private void OnGUI()
        {
            DrawToolbar();
            DrawTreeView();
            DrawIdInspector();
            DrawSeparator();
            HandleSeparatorMouse();
        }

        private void DrawToolbar()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            if (GUILayout.Button("Refresh", EditorStyles.toolbarButton))
            {
                treeView.Reload();
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawTreeView()
        {
            if (treeView.ItemCount == 0)
            {
                return;
            }
            
            var treeViewRect = new Rect(
                0, 
                EditorStyles.toolbar.fixedHeight, 
                separatorPosition, 
                position.height - EditorStyles.toolbar.fixedHeight);
            treeView.OnGUI(treeViewRect);
        }

        private void DrawIdInspector()
        {
            var editorRect = new Rect(
                separatorPosition,
                EditorStyles.toolbar.fixedHeight,
                position.width - separatorPosition,
                position.height - EditorStyles.toolbar.fixedHeight);

            idInspector.Draw(editorRect);
        }

        private void DrawSeparator()
        {
            var rect = new Rect(separatorPosition, EditorStyles.toolbar.fixedHeight, 1, position.yMax);
            EditorGUI.DrawRect(rect, EditorGUIUtility.isProSkin ? Color.black : Color.gray);
        }

        private void HandleSeparatorMouse()
        {
            var cursorRect = new Rect(separatorPosition - 4, EditorStyles.toolbar.fixedHeight, 8, position.yMax);
            EditorGUIUtility.AddCursorRect(cursorRect, MouseCursor.ResizeHorizontal);

            var evt = Event.current;
            if (!evt.isMouse)
            {
                return;
            }

            if (!cursorRect.Contains(evt.mousePosition) && !isDragging)
            {
                return;
            }

            switch (evt.type)
            {
                case EventType.MouseDown:
                    isDragging = true;
                    break;
                case EventType.MouseUp:
                    isDragging = false;
                    break;
                case EventType.MouseDrag:
                    separatorPosition += Mathf.RoundToInt(evt.delta.x);
                    break;
            }

            separatorPosition = Mathf.RoundToInt(
                Mathf.Clamp(separatorPosition,
                position.width * DividerMinimum,
                position.width * DividerMaximum));
            evt.Use();
        }
    }
}