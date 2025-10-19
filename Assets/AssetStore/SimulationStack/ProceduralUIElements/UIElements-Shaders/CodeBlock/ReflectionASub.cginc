
float MaskA = smoothstep(_EdgeBlur, 0, abs(MaskSDF)- _RimWidth);
float MaskB = smoothstep(_EdgeBlur, 0, MaskSDF);
float Mask = _EnableRim == 1 ? MaskA : MaskB;

if (_EnableMaskColor == 1)
{
    col.a +=  0.5 * Mask;
}

col.a *= Mask;
col.a *= _Opacity;


