using System;
using UnityEngine;

namespace QuitCut.Configs.Code
{
    [Serializable]
    class ColorInfo
    {
        public int Count;
        public Color Color;
    }
    [CreateAssetMenu(fileName = "WeeklyWidgetColors", menuName = "QuitCut/WeeklyWidgetColors", order = 0)]
    public class WeeklyWidgetColors : ScriptableObject
    {
        [SerializeField] private ColorInfo[] _colorByCount;
        [SerializeField] public  Color FutureDayColor;
        [SerializeField] public Color TodayColor;
        
        public Color GetColorForCount(int count)
        {
            for (int i = 0; i < _colorByCount.Length; i++)
            {
                if (count <= _colorByCount[i].Count)
                {
                    return _colorByCount[i].Color;
                }
            }
            return _colorByCount[^1].Color;
        }
    }
}