using Sirenix.OdinInspector;
using UnityEngine;
 
[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
    [SerializeField] RectTransform safeArea;
    [SerializeField, OnValueChanged(nameof(Refresh))] 
    // [Range(0f, 1f)] private float compensateTopNotchPercent = 0;
    
    Rect LastSafeArea = new Rect (0, 0, 0, 0);

    
    void OnEnable ()
    {
        Refresh ();
    }

    void Refresh ()
    {
        Rect currentSafeArea = GetSafeArea ();

        if (currentSafeArea != LastSafeArea)
            ApplySafeArea (currentSafeArea);
    }

    Rect GetSafeArea ()
    {
        return Screen.safeArea;
    }

    void ApplySafeArea (Rect r)
    {
        LastSafeArea = r;

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        // if (anchorMax.y < 1f)
        // {
        //     float diff = 1f - anchorMax.y;
        //     diff *= compensateTopNotchPercent;
        //     anchorMax.y += diff;
        // }
        
        safeArea.anchorMin = anchorMin;
        safeArea.anchorMax = anchorMax;
    }
}
