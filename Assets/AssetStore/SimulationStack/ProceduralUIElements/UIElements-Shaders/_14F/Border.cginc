
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0 || _MaskContainer > 1)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = 0;
    if (_MaskContainer == 0)
    {
        SDF = length(UV) - _CircleRadius;
    }
    else if (_MaskContainer == 1)
    {
        #include "../CodeBlock/RectangleCodeBlock.cginc"
        SDF = RoundBoxSDF(UV, float2(_Width, _Height), _CornerRoundness);
    }
    #include "../CodeBlock/BorderA.cginc"
    col *= i.color;
    return col;
}
