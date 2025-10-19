float4 UVT = float4(i.uvgrab.x, i.uvgrab.y, i.uvgrab.z, i.uvgrab.w);
float TempSDF = _EnableRim == 0 ? abs(SDF) : -(abs(SDF) - _RimWidth);
if (_DistortionType == 0)
{
    UVT.xy *= 1.0 - _Distortion * smoothstep(_DistortionArea, 0.0, TempSDF) * UV.x;
}
else
{
    UVT.xy *= 1.0 - _Distortion * smoothstep(_DistortionArea, 0.0, TempSDF) * UV.xy;
}

if (_EnableBlur == 1)
{
#define GRABPIXEL(weight,kernel) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(float4(UVT.x + _GrabTexture_TexelSize.x * kernel*_BlurMagnitude, UVT.y + _GrabTexture_TexelSize.y * kernel*_BlurMagnitude, UVT.z, UVT.w))) * weight
    col += GRABPIXEL(0.025, -7.0);
    col += GRABPIXEL(0.05, -6.0);
    col += GRABPIXEL(0.075, -5.0);
    col += GRABPIXEL(0.1, -4.0);
    col += GRABPIXEL(0.125, -3.0);
    col += GRABPIXEL(0.15, -2.0);
    col += GRABPIXEL(0.175, -1.0);
    col += GRABPIXEL(0.20, 0.0);
    col += GRABPIXEL(0.175, +1.0);
    col += GRABPIXEL(0.15, +2.0);
    col += GRABPIXEL(0.125, +3.0);
    col += GRABPIXEL(0.10, +4.0);
    col += GRABPIXEL(0.075, +5.0);
    col += GRABPIXEL(0.05, +6.0);
    col += GRABPIXEL(0.025, +7.0);
    col /= 1.6;
}
else
{
#define GRABPIXELB(weight) tex2Dproj( _GrabTexture, UNITY_PROJ_COORD(UVT))
    col = GRABPIXELB(1.0);
}