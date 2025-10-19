
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "../CodeBlock/Variables_3.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"
#include "../CodeBlock/Variables_GradientA.cginc"
float _EnableDisplaceShape;
fixed4 _BGColor;
float _DisplaceShapeEdgeBlur;
float _ShapeOffsetX;
float _ShapeOffsetY;

fixed4 frag(v2f i) : SV_Target
{
    #include "../CodeBlock/SizeRatioA.cginc"
    UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
    UV = RotateXY(UV, _Rotation);
    float SDF = StarSDF(UV, _Size , _Turns, _EdgeAngle) - _CornerRoundness;
    float Rim = 0;
    #include "../CodeBlock/DropShadowA.cginc"

    UV = UV + float2(_DropShadowXOffset, _DropShadowYOffset);
    #include "../CodeBlock/GradientA.cginc"
    float DisplaceShapeSDF = StarSDF(UV - float2(_ShapeOffsetX, _ShapeOffsetY), _Size, _Turns, _EdgeAngle) - _CornerRoundness;
    fixed4 BaseColor = (_EnableDisplaceShape == 0) ? SelectedColor : lerp(_BGColor, SelectedColor, smoothstep(_DisplaceShapeEdgeBlur, 0, DisplaceShapeSDF));
    float SDFA = StarSDF(UV, _Size , _Turns, _EdgeAngle) - _CornerRoundness;

    if (_EnableDropShadow == 1)
    {
        col *= smoothstep(0, _EdgeBlur,  SDFA);
        col += smoothstep(_EdgeBlur, 0, SDFA) * BaseColor;
    }
    else
    {
        col = smoothstep(_EdgeBlur, 0, SDFA) * BaseColor;
    }

    col *= i.color;
    return col;
}