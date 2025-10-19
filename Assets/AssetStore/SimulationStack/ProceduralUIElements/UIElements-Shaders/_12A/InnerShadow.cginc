
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_InnerShadowB.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableInnerShadow == 0)
        return 0;

    #include "/CodeBlock.cginc"
    float SDF = RoundBoxSDFB(UV, float2(_Width, _Height), Roundness);
    float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
    float ShadowSDF = RoundBoxSDFB(ShadowUV, float2(_Width, _Height), Roundness);
    #include "../CodeBlock/InnerShadowB.cginc"
    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
