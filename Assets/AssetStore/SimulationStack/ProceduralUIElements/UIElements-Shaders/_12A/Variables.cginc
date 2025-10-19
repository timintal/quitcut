
float4 _ImageSizeRatio;

float _ChooseDimensionParameters;
float _Width, _Height;
float _WidthMargin, _HeightMargin;

float _ChooseRoundnessMode;
float _CornerRoundness;
float _TopLeftCornerRoundness;
float _TopRightCornerRoundness;
float _BottomRightCornerRoundness;
float _BottomLeftCornerRoundness;
float _EdgeBlur;
float _EnableBending;
float _MirrorBending;
float _BendX;
float _BendY;

float RoundBoxSDFB(float2 p, float2 b, float4 r)
{
    r.xy = (p.x > 0.0) ? r.xy : r.zw;
    r.x = (p.y > 0.0) ? r.x : r.y;
    float2 q = abs(p) - b + r.x;
    return min(max(q.x, q.y), 0.0) + length(max(q, 0.0)) - r.x;
}

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}

float RoundBoxSDF(float2 UV, float2 Dimension, float Radius)
{
    return BoxSDF(UV, Dimension) - Radius;
}




