using EasyTweens;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class BezierExtensions
{
    public static Vector3 GetPoint(List<Vector3> points, float t)
    {
        if (points.Count < 2 || points.Count > 4)
        {
            Debug.LogError($"Bezier: Invalid number of points: {points.Count}");
        }

        switch (points.Count)
        {
            case 2:
                return Vector3.Lerp(points[0], points[1], t);
            case 3:
                return Bezier.GetPoint(points[0], points[1], points[2], t);
            case 4:
                return Bezier.GetPoint(points[0], points[1], points[2], points[3], t);
            default:
                return Vector3.zero;
        }
    }
    
    public static float2 GetPoint(float2 p0, float2 p1, float2 p2, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
    }
    
    public static float2 GetFirstDerivative(float2 p0, float2 p1, float2 p2, float t)
    {
        return 2f * (1f - t) * (p1 - p0) + 2f * t * (p2 - p1);
    }
    
    public static float3 GetPoint(float3 p0, float3 p1, float3 p2, float3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float OneMinusT = 1f - t;
        return OneMinusT * OneMinusT * OneMinusT * p0 + 3f * OneMinusT * OneMinusT * t * p1 + 3f * OneMinusT * t * t * p2 + t * t * t * p3;
    }
    
    public static float2 GetPoint(float2 p0, float2 p1, float2 p2, float2 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float OneMinusT = 1f - t;
        return OneMinusT * OneMinusT * OneMinusT * p0 + 3f * OneMinusT * OneMinusT * t * p1 + 3f * OneMinusT * t * t * p2 + t * t * t * p3;
    }
    
    public static float3 GetFirstDerivative(float3 p0, float3 p1, float3 p2, float3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return 3f * oneMinusT * oneMinusT * (p1 - p0) + 6f * oneMinusT * t * (p2 - p1) + 3f * t * t * (p3 - p2);
    }


}
