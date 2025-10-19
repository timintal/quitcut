
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_4.cginc"
#include "../CodeBlock/Variables_ColorModeA.cginc"
float _EnableColor;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableColor == 0)
        return 0;

    float Rim = _EnableRim?_RimWidth:1;
    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_4.cginc"
    #include "../CodeBlock/ColorModeA.cginc"
    col = SelectedColor;
    #include "../CodeBlock/RimSDFBlock.cginc"
    #include "../CodeBlock/PointsIdentifier.cginc"
    col *= i.color;
    return col;
}
