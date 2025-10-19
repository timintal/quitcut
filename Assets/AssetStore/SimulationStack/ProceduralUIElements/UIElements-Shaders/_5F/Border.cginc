
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    UV = RotateXY(UV, _Rotation);
    float SDF = CalculateSDF(UV);
    if (_EnableRim == 1)
    {
        SDF = abs(SDF) - _RimWidth;
    }
    #include "../CodeBlock/BorderA.cginc"
    col *= i.color;
    return col;
}
