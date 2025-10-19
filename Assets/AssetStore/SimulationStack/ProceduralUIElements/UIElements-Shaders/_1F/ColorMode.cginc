
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_1.cginc"
float _InnerShadowSize, _InnerShadowSpread, _InnerShadowXOffset, _InnerShadowYOffset;
float _DotRadius, _DotEdgeBlur, _DotXOffset, _DotYOffset;
#include "../CodeBlock/Variables_ColorModeB.cginc"

fixed4 frag(v2f i) : SV_Target
{
    float Rim = _EnableRim == 1 ? _RimWidth : 1;
    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = length(UV) - _Radius;
    float SDFB = length(UV - float2(_InnerShadowXOffset, _InnerShadowYOffset)) - (_Radius - _InnerShadowSize);
    float SDFC = length(UV - float2(_DotXOffset, _DotYOffset)) - _DotRadius;
    #include "../CodeBlock/ColorModeB.cginc"
    col = SelectedColor;
    col.a = smoothstep(_EdgeBlur, 0.0, SDF) * smoothstep(0, _InnerShadowSpread, SDFB);
    col.a += smoothstep(_DotEdgeBlur * 0.1, 0.0, SDFC);
    col *= i.color;
    return col;
}
