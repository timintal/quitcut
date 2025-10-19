
float4 _ImageSizeRatio;

float _ChooseDimensionParameters;
float _Width, _Height;
float _WidthMargin, _HeightMargin;

float _ChooseRoundnessMode;
float _CornerRoundness;
float _TopLeftCornerRoundness, _TopRightCornerRoundness, _BottomRightCornerRoundness, _BottomLeftCornerRoundness;

float _EdgeBlur;

float _WidthFillAmount, _HeightFillAmount;

#include "../CodeBlock/Variables_RimA.cginc"
#include "../CodeBlock/Variables_BendA.cginc"


float RoundBoxSDFB(float2 p, float2 b, float4 r)
{
    r.xy = (p.x > 0.0) ? r.xy : r.zw;
    r.x = (p.y > 0.0) ? r.x : r.y;
    float2 q = abs(p) - b + r.x;
    return min(max(q.x, q.y), 0.0) + length(max(q, 0.0)) - r.x;
}
