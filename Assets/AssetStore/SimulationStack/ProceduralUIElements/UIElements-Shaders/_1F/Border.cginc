
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "../CodeBlock/Variables_1.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"
fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    float SDF = length(UV) - _Radius;
    #include "../CodeBlock/BorderA.cginc"
    col *= i.color;
    return col;
}
