
#include "../CodeBlock/BaseFilesB.cginc"
#include "../CodeBlock/Variables_2.cginc"
float _EnableDisplaceShape;
fixed4 _BGColor;
float _DisplaceShapeEdgeBlur;
float _ShapeOffsetX;
float _ShapeOffsetY;
#include "../CodeBlock/Variables_ColorModeA.cginc"
float _EnableBorder;
float _EnableColor;
float _FillAmount,_FillAmountY;

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableColor == 0)
        return 0;

    float Rim = _EnableRim==1?_RimWidth:1;
    #include "../CodeBlock/SizeRatioA.cginc"
    #include "../CodeBlock/CodeBlock_2.cginc"
    #include "../CodeBlock/ColorModeA.cginc"
    float DisplaceShapeSDF = RoundBoxSDFB(UV - float2(_ShapeOffsetX, _ShapeOffsetY), float2(_Width, _Height), Roundness);
    col = (_EnableDisplaceShape == 0) ? SelectedColor : lerp(_BGColor, SelectedColor, smoothstep(_DisplaceShapeEdgeBlur, 0, DisplaceShapeSDF));
    #include "../CodeBlock/RimSDFBlock.cginc"
    col *= i.color;
    return col;
}