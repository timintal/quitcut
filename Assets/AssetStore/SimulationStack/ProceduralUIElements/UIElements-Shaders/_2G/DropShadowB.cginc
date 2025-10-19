
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_2.cginc"
float _FillAmount;
float _EnableDropShadowB;
float _DropShadowBSize;
float _DropShadowBSpread;
float _DropShadowBGamma;
float _DropShadowBOpacity;
float _DropShadowBXOffset, _DropShadowBYOffset;
float _DropShadowBColorMode;
fixed4 _DropShadowBColor;
float _DropShadowBGradientMode;
fixed4 _ColorBE, _ColorBF, _ColorBG, _ColorBH;
float _DropShadowBGradientAngle, _DropShadowBGradientScale, _DropShadowBGradientSpread;
float _DropShadowBGradientXOffset, _DropShadowBGradientYOffset;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadowB == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_2.cginc"
    UV = UV - float2(_DropShadowBXOffset, _DropShadowBYOffset);
    SDF = RoundBoxSDFB(UV - float2(WidthFill - _Width, HeightFill - _Height), float2(WidthFill, HeightFill), Roundness);
    SDF -= _DropShadowBSize;
    SDF = _EnableRim == 0 ? SDF : abs(SDF);
    fixed4 Gradient = FourColorGradientA(UV, _DropShadowBGradientAngle, _ColorBE, _ColorBF, _ColorBG, _ColorBH, _DropShadowBGradientMode, 0, _DropShadowBGradientScale, 1, 0);
    col = _DropShadowBColorMode == 0 ? _DropShadowBColor : Gradient;
    col.a = smoothstep(_DropShadowBSpread, 0, SDF) * _DropShadowBOpacity;
    col.a = pow(col.a, _DropShadowBGamma);
    col *= i.color;
    return col;
}