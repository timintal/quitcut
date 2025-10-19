
if (_ColorMode == 0)
{
    SelectedColor = _Color;
}
else
{
    ColorUV = RotateXY(UV - float2(_TexXOffset, _TexYOffset), _TexRotation);
    ColorUV *= 1 / _TexScale;

    if (_MainTex_TexelSize.z > _MainTex_TexelSize.w)
    {
        ColorUV.y *= _MainTex_TexelSize.z / _MainTex_TexelSize.w;
    }
    else if (_MainTex_TexelSize.z < _MainTex_TexelSize.w)
    {
        ColorUV.x *= _MainTex_TexelSize.w / _MainTex_TexelSize.z;
    }
    float Clipping = _TexClipping == 1 ? smoothstep(0.5, 0.499, abs(ColorUV.x)) * smoothstep(0.5, 0.499, abs(ColorUV.y)) : 1;
    SelectedColor = tex2D(_MainTex, ColorUV + float2(0.5, 0.5)) * Clipping;
}
