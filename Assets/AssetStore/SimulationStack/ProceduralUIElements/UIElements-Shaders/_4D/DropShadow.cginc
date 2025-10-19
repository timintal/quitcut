
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_4.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
    #include "../CodeBlock/CodeBlock_4.cginc"
    float Rim = _EnableRim;
    #include "../CodeBlock/DropShadowA.cginc"
    col *= i.color;
    return col;
}
