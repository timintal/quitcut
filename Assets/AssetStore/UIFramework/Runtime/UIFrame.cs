using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Threading;
using Libraries.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UIFramework.Runtime
{
    public enum OnScreenEvent
    {
        Created,
        Opening,
        Opened,
        Closing,
        Closed,
        Destoryed,
        MAX
    }

    /// <summary>
    /// This is the centralized access point for all things UI.
    /// All your calls should be directed at this.
    /// </summary>
    public class UIFrame : MonoBehaviour
    {
        public Canvas MainCanvas => _mainCanvas;
        public Camera UICamera => MainCanvas.worldCamera;

        private Canvas _mainCanvas;
        private GraphicRaycaster _graphicRaycaster;

        private UISettings _uiSettings;

        // Lookup dictionaries
        private readonly Dictionary<string, UILayer> _layersByName = new Dictionary<string, UILayer>();
        private readonly Dictionary<Type, UILayer> _layersByScreenType = new Dictionary<Type, UILayer>();

        private const int _maxScreenEvents = (int)OnScreenEvent.MAX;
        private Dictionary<Type, Action>[] _onSpecificScreenEvent = new Dictionary<Type, Action>[_maxScreenEvents];
        private Action<UIScreenBase>[] _onScreenEvent = new Action<UIScreenBase>[_maxScreenEvents];

        private int _screenBlockCount;

        private bool _isInitialized;

        AutoInjectFactory _factory;

        internal void Construct(UISettings uiSettings, Canvas canvas)
        {
            _uiSettings = uiSettings;
            _mainCanvas = canvas;
        }

        [PublicAPI]
        public void Initialize(AutoInjectFactory factory, Camera cam = null)
        {
            _factory = factory;
            for (int i = 0; i < (int)OnScreenEvent.MAX; i++)
            {
                _onSpecificScreenEvent[i] = new Dictionary<Type, Action>();
            }

            if (cam != null)
            {
                // For having the same scene view with the game view
                MainCanvas.worldCamera = cam;
                // Assigning a camera to the canvas changes sorting values, we have set them again
                MainCanvas.sortingOrder = _uiSettings.orderInLayer;
                MainCanvas.sortingLayerName = _uiSettings.sortingLayerName;
                MainCanvas.sortingLayerID = SortingLayer.NameToID(_uiSettings.sortingLayerName);
            }

            _graphicRaycaster = MainCanvas.GetComponent<GraphicRaycaster>();

            // Create layers, screens will be created by layers
            foreach (var layerInfo in _uiSettings.layers)
            {
                layerInfo.BackgroundBlockerColor = _uiSettings.backgroundBlockerColor;
                CreateLayer(layerInfo, factory);
            }

            // Add screens to lookup dict
            foreach (var layer in GetAllLayers())
            {
                foreach (var screenType in layer.GetAllScreenTypes())
                {
                    _layersByScreenType.Add(screenType, layer);
                }
            }

            _isInitialized = true;
        }

        private UILayer CreateLayer(LayerInfo layerInfo, AutoInjectFactory factory)
        {
            // Create gameObject
            var layerObject = new GameObject(layerInfo.Name);

            // Add UILayer component
            var layer = layerObject.AddComponent<UILayer>();

            // Add rect transform and set to full stretched
            var layerRT = layerObject.AddComponent<RectTransform>();
            layerRT.anchorMin = new Vector2(0, 0);
            layerRT.anchorMax = new Vector2(1, 1);

            // Move layer to UIFrame
            layerObject.transform.SetParent(transform, false);

            // Set rect transform size delta to ensure full stretched
            layerRT.sizeDelta = Vector3.zero;

            // Add to lookup dict
            _layersByName.Add(layerInfo.Name, layer);

            // Initialize layer, this will create the screens
            layer.InitializeLayer(this, layerInfo, factory);

            // Register screen block requests
            layer.RequestUIInteractionBlock += RequestUIInteractionBlock;
            layer.RequestUIInteractionUnblock += RequestUIInteractionUnblock;
            return layer;
        }

#if UNITY_ANDROID || UNITY_EDITOR
        // Back button listener for android
        private void Update()
        {
            if (!_isInitialized) return;

            // KeyCode.Escape is back button on android
            if (!Keyboard.current.escapeKey.wasReleasedThisFrame) return;

            // if it is not enabled, opening or closing animation is active
            if (!_graphicRaycaster.enabled) return;

            UILayer topMostPopupLayer = null;
            Type popupToClose = null;
            bool foundPopupToClose = false;
            foreach (var layer in _layersByName.Values)   
            {
                if (layer.GetLayerInfo().LayerType == LayerType.Popup)
                {
                    topMostPopupLayer = layer;
                    foreach (var screen in layer.ScreensByType)
                    {
                        if (screen.Value != null && screen.Value.GetState() == ScreenState.Opened)
                        {
                            var screenInfo = layer.GetScreenInfo(screen.Key);
                            if (screenInfo.CloseWithEscape)
                            {
                                popupToClose = screen.Key;
                                foundPopupToClose = true; //and keep cycling to close the top most popup
                            }
                        }
                    }
                }
            }

            if (foundPopupToClose)
            {
                topMostPopupLayer.CloseScreen(popupToClose);
            }
        }
#endif
        [PublicAPI]
        public UILayer AddLayer(string newLayerName, LayerType newLayerType, string beforeThisLayerName)
        {
            LayerInfo layerInfo = new LayerInfo
            {
                Name = newLayerName,
                LayerType = newLayerType,
                Screens = new List<ScreenInfo>()
            };
            layerInfo.BackgroundBlockerColor = _uiSettings.backgroundBlockerColor;
            var layerCreated = CreateLayer(layerInfo, _factory);

            var siblingLayer = GetLayerByName(beforeThisLayerName);
            if (siblingLayer != null)
            {
                layerCreated.transform.SetSiblingIndex(siblingLayer.transform.GetSiblingIndex());
            }

            return layerCreated;
        }

        [PublicAPI]
        public void AddScreenInfo(UILayer layer, ScreenInfo screenInfo)
        {
            if (layer != null)
            {
                layer.AddScreenInfo(screenInfo);
                _layersByScreenType.Add(screenInfo.Prefab.GetType(), layer);
            }
        }

        [PublicAPI]
        public void RemoveScreenInfo<T>()
        {
            RemoveScreenInfo(typeof(T));
        }

        [PublicAPI]
        public void RemoveScreenInfo(Type screenType)
        {
            var layer = GetLayerByScreenType(screenType);
            if (layer == null)
            {
                Debug.LogError(
                    "UIFrame : Layer not found for the screen type of " + screenType.Name);
                return;
            }

            if (layer.RemoveScreenInfo(screenType))
            {
                _layersByScreenType.Remove(screenType);
            }
        }

        [PublicAPI]
        public UILayer GetLayerByName(string layerName)
        {
            return _layersByName.TryGetValue(layerName, out var layer) ? layer : null;
        }

        [PublicAPI]
        public UILayer GetLayerByScreenType<T>()
        {
            return GetLayerByScreenType(typeof(T));
        }

        [PublicAPI]
        public UILayer GetLayerByScreenType(Type screenType)
        {
            return _layersByScreenType.TryGetValue(screenType, out var layer) ? layer : null;
        }

        [PublicAPI]
        public List<UILayer> GetAllLayers()
        {
            return _layersByName.Values.ToList();
        }

        [PublicAPI]
        public T GetScreen<T>() where T : UIScreenBase
        {
            var layer = GetLayerByScreenType<T>();
            return layer != null ? layer.GetScreen<T>() as T : null;
        }

        [PublicAPI]
        public UniTask<T> OpenAsync<T>(IScreenProperties properties = null, AutoInjectFactory customContext = null) where T : UIScreenBase
        {
            return GetLayerByScreenType<T>().OpenScreen<T>(properties, customContext);
        }
        
        [PublicAPI]
        public async UniTask OpenAndWaitForClosing<T>(
            IScreenProperties properties = null,
            CancellationToken ct = default(CancellationToken),
            AutoInjectFactory customContext = null) where T : UIScreenBase
        {
            var screen = await GetLayerByScreenType<T>().OpenScreen<T>(properties, customContext);
            await UniTask.WaitUntil(screen, s => s.GetState() == ScreenState.Closed, cancellationToken:ct);
        }
        
        [PublicAPI]
        public async UniTask WaitForClosing<T>(CancellationToken ct) where T : UIScreenBase
        {
            while(IsVisible<T>() && !ct.IsCancellationRequested)
            {
                await UniTask.Yield(ct);
            }
        }
        
        [PublicAPI]
        public UniTask<UIScreenBase> OpenAsync(Type screenType, IScreenProperties properties = null, AutoInjectFactory customContext = null)
        {
            return GetLayerByScreenType(screenType).OpenScreen(screenType, properties, customContext);
        }

        [PublicAPI]
        public void Close<T>() where T : UIScreenBase
        {
            GetLayerByScreenType<T>().CloseScreen<T>();
        }
        
        public void CloseIfOpened<T>() where T : UIScreenBase
        {
            var screen = GetScreen<T>();
            if (screen != null && screen.GetState() == ScreenState.Opened)
            {
                Close<T>();
            }
        }

        [PublicAPI]
        public void Close(Type screenType)
        {
            var layer = GetLayerByScreenType(screenType);
            if (layer != null)
            {
                layer.CloseScreen(screenType);
            }
        }

        [PublicAPI]
        public bool IsInitialized()
        {
            return _isInitialized;
        }

        /// <summary>
        /// A screen is visible when it is opening, opened or closing
        /// </summary>
        [PublicAPI]
        public bool IsVisible<T>() where T : UIScreenBase
        {
            var screen = GetScreen<T>();
            return screen != null && screen.GetState() != ScreenState.Closed;
        }

        /// <summary>
        /// A screen is shown when it has completed opening transition
        /// </summary>
        [PublicAPI]
        public bool IsOpen<T>() where T : UIScreenBase
        {
            var screen = GetScreen<T>();
            return screen != null && screen.GetState() == ScreenState.Opened;
        }
        
        /// <summary>
        /// A screen is opening when it is in the process of opening
        /// </summary>
        [PublicAPI]
        public bool IsOpening<T>() where T : UIScreenBase
        {
            var screen = GetScreen<T>();
            return screen != null && screen.GetState() == ScreenState.Opening;
        }
        
        /// <summary>
        /// A screen is closing when it is in the process of closing
        /// </summary>
        [PublicAPI]
        public bool IsClosing<T>() where T : UIScreenBase
        {
            var screen = GetScreen<T>();
            return screen != null && screen.GetState() == ScreenState.Closing;
        }

        [PublicAPI]
        public void RequestUIInteractionBlock()
        {
            _screenBlockCount++;
            if (_graphicRaycaster != null)
            {
                _graphicRaycaster.enabled = false;
            }
        }

        [PublicAPI]
        public void RequestUIInteractionUnblock()
        {
            _screenBlockCount--;
            if (_graphicRaycaster != null && _screenBlockCount <= 0)
            {
                _screenBlockCount = 0;
                _graphicRaycaster.enabled = true;
            }
        }

        [PublicAPI]
        public bool IsInteractable()
        {
            return _graphicRaycaster.enabled;
        }

        internal void OnScreenEventInternal(OnScreenEvent ev, UIScreenBase screen)
        {
            var actionDict = _onSpecificScreenEvent[(int)ev];
            var t = screen.GetType();
            if (actionDict.ContainsKey(t))
            {
                actionDict[t]?.Invoke();
            }

            _onScreenEvent[(int)ev]?.Invoke(screen);
        }

        [PublicAPI]
        public void AddEventForAllScreens(OnScreenEvent ev, Action<UIScreenBase> cb)
        {
            _onScreenEvent[(int)ev] += cb;
        }

        [PublicAPI]
        public void RemoveEventForAllScreens(OnScreenEvent ev, Action<UIScreenBase> cb)
        {
            _onScreenEvent[(int)ev] -= cb;
        }

        [PublicAPI]
        public void AddEventForScreen<T>(OnScreenEvent ev, Action cb)
        {
            var actionDict = _onSpecificScreenEvent[(int)ev];
            var screen = typeof(T);
            if (!actionDict.ContainsKey(screen))
            {
                actionDict[screen] = cb;
            }
            else

            {
                actionDict[screen] += cb;
            }
        }

        [PublicAPI]
        public void RemoveEventForScreen<T>(OnScreenEvent ev, Action cb)
        {
            var actionDict = _onSpecificScreenEvent[(int)ev];
            var screen = typeof(T);
            if (actionDict.ContainsKey(screen))
            {
                actionDict[screen] -= cb;
            }
        }

        [PublicAPI]
        public void RemoveAllEventsForScreen<T>(OnScreenEvent ev)
        {
            var actionDict = _onSpecificScreenEvent[(int)ev];
            var screen = typeof(T);
            if (actionDict.ContainsKey(screen))
            {
                actionDict[screen] = null;
            }
        }
    }
}