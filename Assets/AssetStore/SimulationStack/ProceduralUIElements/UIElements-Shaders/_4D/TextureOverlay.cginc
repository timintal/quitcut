
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_4.cginc"
#include "../CodeBlock/Variables_TextureOverlayA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableTextureOverlay == 0)
        return 0;

    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_4.cginc"
    if (_EnableRim == 1)
    {
        SDF = abs(SDF) - _RimWidth;
    }
    #include "../CodeBlock/TextureOverlayA.cginc"
    col *= i.color;
    return col;
}
