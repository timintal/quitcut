using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuitCut.NavBar
{
    public class NavBarButton : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _selection;
    
        Type _type;
        Action _onClick;
        
        public Type Type => _type;

        public void Initialize(Sprite icon, string label, Type type, Action onClick)
        {
            _icon.sprite = icon;
            if (_label != null)
                _label.text = label;
            _onClick = onClick;
            _type = type;
        }
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void OnClick()
        {
            _onClick?.Invoke();
        }

        public void SetSelected(bool selected)
        {
            _selection.SetActive(selected);
        }

    }
}