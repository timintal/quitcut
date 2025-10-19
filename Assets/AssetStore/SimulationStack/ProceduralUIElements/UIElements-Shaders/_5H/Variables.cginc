
float4 _ImageSizeRatio;
float _Size;
float _Thickness;
float _EdgeAngle;
float _CornerRoundness;
float _EnableRim;
float _RimWidth;
float _RimGamma;
float _EdgeBlur;
float _Rotation;

float SDF = 0;

float CrossSDF(float2 p, float2 b, float r)
{
    p = abs(p); p = (p.y > p.x) ? p.yx : p.xy;
    float2  q = p - b;
    float k = max(q.y, q.x);
    float2  w = (k > 0.0) ? q : float2(b.y - p.x, -k);
    float d = length(max(w, 0.0));
    return ((k > 0.0) ? d : -d) + r;
}

float CalculateSDF(float2 UV)
{
    return CrossSDF(UV, float2(_Size, _Thickness), _EdgeAngle) - _CornerRoundness;
}
