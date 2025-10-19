
float Rim = 1;
if (_MaskContainer <4)
{
    if (_EnableRim == 1)
    {
        Rim = smoothstep(_RimWidth, _RimWidth * (0.999 - _EdgeBlur * 10.0), abs(SDF));
    }
    else
    {
        Rim = smoothstep(_EdgeBlur, 0.0, SDF);
    }
}
