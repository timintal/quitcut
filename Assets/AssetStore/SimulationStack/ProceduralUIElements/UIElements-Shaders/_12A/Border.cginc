#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0)
        return 0;

    #include "/CodeBlock.cginc"
    float SDF = RoundBoxSDFB(UV, float2(_Width, _Height), Roundness);
    #include "../CodeBlock/BorderA.cginc"
    col *= i.color;
    return col;
}
