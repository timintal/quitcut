
#include "../CodeBlock/BaseFilesB.cginc"
#include "/Variables.cginc"
#include "../CodeBlock/Variables_ColorModeA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    float Rim = 1;
    #include "../CodeBlock/SizeRatioB.cginc"
    #include "/CodeBlock.cginc"
    UV = _ApplyColorModeToEachCell == 0 ? UV : CellUV;
    #include "../CodeBlock/ColorModeA.cginc"
    float Fill = ((floor(i.uv * _NoOfCells).x / (_NoOfCells)) < _FillAmount);
    col = SelectedColor;

    if (_ColorMode == 1)
    {
        col.a = ((floor(i.uv * _NoOfCells).x / (_NoOfCells)) < _FillAmount) ? SelectedColor.a : 0;
    }
    else
    {
        col.a = smoothstep(_EdgeBlur, 0.0, SDF) * Fill;
    }

    if (_ColorMode == 1)
    {
        if (_MainTex_TexelSize.z > _MainTex_TexelSize.w)
        {
            UV.y *= _MainTex_TexelSize.z / _MainTex_TexelSize.w;
        }
        else if (_MainTex_TexelSize.z < _MainTex_TexelSize.w)
        {
            UV.x *= _MainTex_TexelSize.w / _MainTex_TexelSize.z;
        }
        col.a *= smoothstep(0.5, 0.499, abs(UV.y)) * smoothstep(0.5, 0.499, abs(UV.x)) * smoothstep(_EdgeBlur, 0.0, SDF);
    }

    if(_AnimateColorAlpha>0)
    {
        col.a *= 1.0 - abs(sin(AnimationValue * _AnimationScale + _Time.y * _AnimationSpeed)) * _AnimateColorAlpha;
    }

    col *= i.color;
    return col;
}
