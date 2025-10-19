
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_DropShadowA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableDropShadow == 0)
        return 0;

    #include "../CodeBlock/SizeRatioB.cginc"
    UV = UV - float2(_DropShadowXOffset, _DropShadowYOffset);
    #include "/CodeBlock.cginc"
    float Fill = ((floor(i.uv * _NoOfCells).x / (_NoOfCells)) < _FillAmount);
    float Rim = 0;
    #include "../CodeBlock/DropShadowA.cginc"
    col.a *= Fill;
    if(_AnimateColorAlpha>0)
    {
        col.a *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateColorAlpha;
    }
    col *= i.color;
    return col;
}