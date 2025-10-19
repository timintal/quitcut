#include "../CodeBlock/BaseFilesB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_ColorModeA.cginc"
float _EnableColor;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableColor == 0)
        return 0;
    float Rim = _EnableRim?_RimWidth:1;
    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = CalculateSDF(UV);
    #include "../CodeBlock/ColorModeA.cginc"
    col = SelectedColor;
    #include "../CodeBlock/RimSDFBlock.cginc"
    col *= i.color;
    return col;
}
