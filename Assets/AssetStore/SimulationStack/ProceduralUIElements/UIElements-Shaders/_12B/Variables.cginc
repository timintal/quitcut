
float4 _ImageSizeRatio;
float _Radius;
//float _RingWidth;
float _NumberOfCells;
float _CellHeight;
float _CellWidth;
float _CornerRoundness;
float _EdgeBlur;
float _FillAmount;
float _IncludeBorder;
float _IncludeLines;

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}



float TrapezoidSDF(float2 p, float r1, float r2, float he)
{
    float2 k1 = float2(r2, he);
    float2 k2 = float2(r2 - r1, 2.0 * he);
    p.x = abs(p.x);
    float2 ca = float2(p.x - min(p.x, (p.y < 0.0) ? r1 : r2), abs(p.y) - he);
    float2 cb = p - k1 + k2 * clamp(dot(k1 - p, k2) / dot2(k2), 0.0, 1.0);
    float s = (cb.x < 0.0 && ca.y < 0.0) ? -1.0 : 1.0;
    return s * sqrt(min(dot2(ca), dot2(cb)));
}