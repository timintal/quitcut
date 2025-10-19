
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_BorderA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    if (_EnableBorder == 0)
        return 0;
    
    #include "../CodeBlock/SizeRatioB.cginc"
    #include "/CodeBlock.cginc"
    float Fill = ((floor(i.uv * _NoOfCells).x / (_NoOfCells)) < _FillAmount);
    #include "../CodeBlock/BorderA.cginc"
    col.a *= Fill;
    if(_AnimateColorAlpha>0)
    {
        col.a *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateColorAlpha;
    }
    col *= i.color;
    return col;
}
