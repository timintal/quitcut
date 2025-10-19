
#include "../CodeBlock/BaseFilesB.cginc"
//#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_4.cginc"
#include "../CodeBlock/Variables_LinesA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableLines == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_4.cginc"
    if (_EnableRim == 1)
    {
        SDF = abs(SDF) - _RimWidth;
    }
    #include "../CodeBlock/LinesA.cginc"
    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
