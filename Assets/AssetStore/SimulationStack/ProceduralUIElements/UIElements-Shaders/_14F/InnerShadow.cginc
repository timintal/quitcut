
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_InnerShadowB.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableInnerShadow == 0 || _MaskContainer > 1)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
    float ShadowSDF = 0;
    float SDF = 0;
    if (_MaskContainer == 0)
    {
        ShadowSDF = length(ShadowUV) - _CircleRadius;
        SDF = length(UV) - _CircleRadius;
    }
    else if (_MaskContainer == 1)
    {
        #include "../CodeBlock/RectangleCodeBlock.cginc"
        ShadowSDF = RoundBoxSDF(ShadowUV, float2(_Width, _Height), _CornerRoundness);
        SDF = RoundBoxSDF(UV, float2(_Width, _Height), _CornerRoundness);
    }
    #include "../CodeBlock/InnerShadowB.cginc"
    col.a *= smoothstep(_ContainerEdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
