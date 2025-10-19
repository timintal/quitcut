
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "../CodeBlock/Variables_3.cginc"
#include "../CodeBlock/Variables_InnerShadowB.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableInnerShadow == 0 && _EnableBorder == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
    float SDF = StarSDF(RotateXY(UV,_Rotation), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
    float ShadowSDF = StarSDF(RotateXY(ShadowUV, _Rotation), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
    #include "../CodeBlock/InnerShadowBorder.cginc"
    col *= i.color;
    return col;
}