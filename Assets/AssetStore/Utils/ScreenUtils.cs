#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Common
{

    public static class ScreenUtils
    {
        static readonly Type GameViewWindowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameView");

        static readonly PropertyInfo SelectedSizeIndexProperty = GameViewWindowType.GetProperty("selectedSizeIndex",
            BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.NonPublic);

        public static int GetSelectedIndex()
        {
            var gameViewWindow = EditorWindow.GetWindow(GameViewWindowType);
            return (int)SelectedSizeIndexProperty.GetValue(gameViewWindow);
        }

        public static Vector2Int GetGameWindowSize()
        {
            var gameViewSizes = typeof(Editor).Assembly.GetType("UnityEditor.GameViewSizes");
            var singleType = typeof(ScriptableSingleton<>).MakeGenericType(gameViewSizes);
            var instanceProp = singleType.GetProperty("instance");
            var gameViewSizesInstance = instanceProp.GetValue(null, null);
            var getGroupMethod = gameViewSizes.GetProperty("currentGroup").GetGetMethod();
            var group = getGroupMethod.Invoke(gameViewSizesInstance, null);
            var getGameViewMethod = group.GetType().GetMethod("GetGameViewSize");
            var gameViewSize = getGameViewMethod.Invoke(group, new object[]{GetSelectedIndex()});
            var widthProperty = gameViewSize.GetType().GetProperty("width");
            var heightProperty = gameViewSize.GetType().GetProperty("height");
            return new Vector2Int((int)widthProperty.GetValue(gameViewSize, null), (int)heightProperty.GetValue(gameViewSize, null));
        }
    }
}
#endif
