
float2 ColorUV = UV;
fixed4 SelectedColor = fixed4(0, 0, 0, 0);
float4 GradientOffset = float4(_GradientXOffset, _GradientYOffset, 0, 0);

if (_ColorMode == 0 || _ColorMode == 1)
{
    #include "/Color_Texture_ColorMode.cginc"
}
else if (_ColorMode == 2)
{
    #include "/RadialGradientA_ColorMode.cginc"
}
else if (_ColorMode == 3)
{
    #include "/LinearGradientA_ColorMode.cginc"
}
else if (_ColorMode == 4)
{
    #include "/SharpBoundaryGradientA_ColorMode.cginc"
}
