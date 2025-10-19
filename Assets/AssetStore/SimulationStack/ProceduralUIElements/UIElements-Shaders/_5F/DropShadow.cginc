
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    UV = RotateXY(UV, _Rotation);
    UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
    float SDF = CalculateSDF(UV);
    float Rim = _EnableRim;
    #include "../CodeBlock/DropShadowA.cginc"
    col *= i.color;
    return col;
}
