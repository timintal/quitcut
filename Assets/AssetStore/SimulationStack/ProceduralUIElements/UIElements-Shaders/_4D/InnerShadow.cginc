
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_4.cginc"
#include "../CodeBlock/Variables_InnerShadowB.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableInnerShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_4.cginc"
    float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
    float ShadowSDF = PolygonSDF(ShadowUV, Points, _NoOfPoints + 3) - _CornerRoundness;
    if (_EnableRim == 1)
    {
        SDF = abs(SDF) - _RimWidth;
        ShadowSDF = abs(ShadowSDF) - _RimWidth;
    }
    #include "../CodeBlock/InnerShadowB.cginc"
    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
