
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_1.cginc"
#include "../CodeBlock/Variables_BendA.cginc"
#include "../CodeBlock/Variables_LinesA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableLines == 0)
        discard;

    #include "/CodeBlock.cginc"
    float SDF = CalculateSDF(UV);
    if (_EnableRim == 1)
    {
        SDF = abs(SDF) - _RimWidth;
    }
    #include "../CodeBlock/LinesA.cginc"
    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
