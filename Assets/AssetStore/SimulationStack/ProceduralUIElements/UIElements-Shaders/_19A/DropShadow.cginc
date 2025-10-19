

#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadow == 0)
        return 0;
    float Rim = _EnableRim;
    #include "../CodeBlock/SizeRatioA.cginc"
    UV -= float2(_DropShadowXOffset, _DropShadowYOffset);
    float SDF = CalculateSDF(UV);
    #include "../CodeBlock/DropShadowA.cginc"
    col *= i.color;
    return col;
}