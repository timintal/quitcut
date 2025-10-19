
#include "../CodeBlock/BaseFilesB.cginc"
#include "/Variables.cginc"
float _EnableContainerColor;
fixed4 _ContainerColor;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableContainerColor == 0)
        return 0;

    #include "/CodeBlock.cginc"
    float SDF = RoundBoxSDFB(UV , float2(_Width, _Height) , Roundness);
    col = _ContainerColor;
    col.a = smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;
    return col;
}