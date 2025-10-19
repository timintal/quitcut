
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_InnerShadowB.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableInnerShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    UV = RotateXY(UV, _Rotation);
    float SDF = CalculateSDF(UV);
    float2 ShadowUV = UV - float2(_InnerShadowXOffset, _InnerShadowYOffset);
    float ShadowSDF = CalculateSDF(ShadowUV); 
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
