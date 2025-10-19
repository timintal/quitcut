
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_6.cginc"
#include "../CodeBlock/Variables_LinesA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableLines == 0)
         return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = HeartSDF_Custom(UV * (12 - _Size));
    #include "../CodeBlock/LinesA.cginc"
    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}
