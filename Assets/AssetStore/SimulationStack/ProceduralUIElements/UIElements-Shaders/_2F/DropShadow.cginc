
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_2.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"
float _FillAmount,_FillAmountY;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_2.cginc"
    UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
    SDF = RoundBoxSDFB(UV - float2(WidthFill - _Width, HeightFill - _Height), float2(WidthFill, HeightFill), Roundness);
    float Rim = _EnableRim;
    #include "../CodeBlock/DropShadowA.cginc"
    col *= i.color;
    return col;
}