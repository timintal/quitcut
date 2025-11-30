using UnityEngine;

namespace Common
{
    public static class ColorUtils
    {
        public static Color WithAlpha(this Color color, float alpha) => new Color(color.r, color.g, color.b, alpha);
    }
}