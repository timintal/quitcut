
float4 _ImageSizeRatio;
float _X_1, _X_2, _X_3, _X_4, _X_5, _X_6, _X_7, _X_8, _X_9, _X_10;
float _Y_1, _Y_2, _Y_3, _Y_4, _Y_5, _Y_6, _Y_7, _Y_8, _Y_9, _Y_10;
float _PointsIdentifier;
float _CornerRoundness;
float _EnableRim;
float _RimWidth;
float _RimGamma;
float _EdgeBlur;
float _NoOfPoints;
float2 Points[10];


float PolygonSDF(float2 p, float2 v[10], float l)
{
    int N = l;
    float d = dot(p - v[0], p - v[0]);
    float s = 1.0;
    for (int i = 0, j = N - 1; i < N; j = i, i++)
    {
        float2 e = v[j] - v[i];
        float2 w = p - v[i];
        float2 b = w - e * clamp(dot(w, e) / dot(e, e), 0.0, 1.0);
        d = min(d, dot(b, b));

        bool one = p.y >= v[i].y;
        bool two = p.y < v[j].y;
        bool three = e.x * w.y > e.y * w.x;

        if ((one && two && three) || (!one && !two && !three)) s = -s;
    }
    return s * sqrt(d);
}