
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_1.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    float Rim = _EnableRim? _RimWidth : 1;
    if (_EnableDropShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = CalculateSDF(UV - float2(_DropShadowXOffset, _DropShadowYOffset));
    #include "../CodeBlock/DropShadowA.cginc"
    col *= i.color;
    return col;
}
