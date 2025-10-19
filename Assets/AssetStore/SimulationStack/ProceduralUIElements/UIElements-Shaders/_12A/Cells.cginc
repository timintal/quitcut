
#include "../CodeBlock/BaseFilesB.cginc"
#include "../Functions/GradientA.cginc"
#include "/Variables.cginc"
fixed4 _BGColor;
float _CellOffset;
float _EnableDisableCell;
fixed4 _DisableCellColor;
float _NoOfCells, _CellWidth, _CellHeight, _CellCornerRoundness, _CellEdgeBlur, _RotateCell, _CellMoveSpeed, _CellsFillAmount;

float _ApplyColorModeToEachCell;
#include "../CodeBlock/Variables_ColorModeA.cginc"

fixed4 frag(v2f i) : SV_Target
{
    float Rim = 1;
    #include "/CodeBlock.cginc"
    float SDF = RoundBoxSDFB(UV, float2(_Width, _Height), Roundness);
    float CellX = UV.x;
    CellX = (CellX * (1 + _CellOffset) + _Width) / (_Width * 2.0);
    CellX = CellX >= 0 && CellX <= 1.0 ? CellX : 0;
    float Clip = CellX > 0?1:0;
    float FillAmount = floor(CellX * _NoOfCells) / _NoOfCells;
    CellX = frac(CellX * _NoOfCells) - 0.5;
    float CellY = (UV.y / (_Width * 2.0)) * _NoOfCells;
    float2 CellUV = float2(CellX, CellY);
    CellUV.y *= (1 + _CellOffset);
    CellUV = RotateXY(CellUV, _RotateCell);
    UV = _ApplyColorModeToEachCell == 0 ? UV : CellUV;
    #include "../CodeBlock/ColorModeA.cginc"
    col = SelectedColor;
    float CellSDF = RoundBoxSDF(CellUV, float2(_CellWidth, _CellHeight), _CellCornerRoundness);
    if (_ColorMode == 1)
    {
        if (_EnableDisableCell == 1)
        {
            fixed4 DisableColor = SelectedColor;
            DisableColor.rgb *= _DisableCellColor.rgb;
            col = (FillAmount < _CellsFillAmount) ? SelectedColor : DisableColor;
        }
        else
        {
            col.a = (FillAmount < _CellsFillAmount) ? SelectedColor.a : 0;
        }
    }
    else
    {
        if (_EnableDisableCell == 1)
        {
            col = (FillAmount < _CellsFillAmount) ? SelectedColor : _DisableCellColor;
            col.a *= smoothstep(_CellEdgeBlur, 0, CellSDF);
        }
        else
        {
            col = (FillAmount <= _CellsFillAmount) ? SelectedColor : fixed4(0, 0, 0, 0);
            col.a = smoothstep(_CellEdgeBlur, 0, CellSDF);
            col.a *= (FillAmount < _CellsFillAmount) ? col.a : 0;
        }
    }
    if (_ColorMode == 1)
    {
        if (_MainTex_TexelSize.z > _MainTex_TexelSize.w)
        {
            CellUV.y *= _MainTex_TexelSize.z / _MainTex_TexelSize.w;
        }
        else if (_MainTex_TexelSize.z < _MainTex_TexelSize.w)
        {
            CellUV.x *= _MainTex_TexelSize.w / _MainTex_TexelSize.z;
        }
        col.a *= Clip * smoothstep(0.5, 0.499, abs(CellUV.y)) * smoothstep(0.5, 0.499, abs(CellUV.x));
    }

    col.a *= smoothstep(_EdgeBlur, 0, SDF);
    col *= i.color;

    return col;
}