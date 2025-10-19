
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"
fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = CalculateSDF(UV);
    SDF = _EnableRim ==1 ?abs(SDF) - _RimWidth:SDF;
    #include "../CodeBlock/BorderA.cginc"
    col *= i.color;
    return col;
}
