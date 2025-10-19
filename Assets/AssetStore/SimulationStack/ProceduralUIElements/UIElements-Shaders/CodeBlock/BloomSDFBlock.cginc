
if (_EnableRim)
{
    col.a = pow((_RimWidth / abs(SDF)), (1.0/ _Bloom));
}
else
{
    col.a = smoothstep(_BloomGamma, 0, SDF);
    col.a += pow((_BloomGamma / abs(SDF)), (1.0/_Bloom));
}
