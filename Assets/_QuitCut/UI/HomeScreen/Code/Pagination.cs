using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace QuitCut
{
    public class Pagination : MonoBehaviour
    {
        [SerializeField] Image _dotPrefab;
        
        List<Image> _dots = new();

        public void SetDotsCount(int count)
        {
            while (_dots.Count < count)
            {
                AddDot();
            }
            while (_dots.Count > count)
            {
                RemoveDot();
            }
        }

        public void SetActivePage(int pageIndex)
        {
            for (int i = 0; i < _dots.Count; i++)
            {
                _dots[i].color = (i == pageIndex) ? _dots[i].color.WithAlpha(1) : _dots[i].color.WithAlpha(0.3f);
            }
        }
        
        public void AddDot()
        {
            var dotInstance = Instantiate(_dotPrefab, transform);
            dotInstance.gameObject.SetActive(true);
            _dots.Add(dotInstance);
        }
        
        public void RemoveDot()
        {
            var lastDot = _dots[^1];
            Destroy(lastDot.gameObject);
            _dots.RemoveAt(_dots.Count - 1);
        }
        public void Clear()
        {
            foreach (var dot in _dots)
            {
                Destroy(dot.gameObject);
            }
            _dots.Clear();
        }
    }
}