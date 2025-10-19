
float4 _ImageSizeRatio;
float _Size;
float _EnableRim;
float _RimWidth;
float _RimGamma;
float _EdgeBlur;

float HeartSDF_Custom(float2 p)
{
    p *= 1.3;
    p.y += 0.55;
    p.x = abs(p.x);
    if (p.y + p.x > 1.0)
        return sqrt(dot2(p - float2(0.25, 0.75))) - sqrt(2.0) / 4.0;
    return sqrt(min(dot2(p - float2(0.00, 1.00)),
        dot2(p - 0.5 * max(p.x + p.y, 0.0)))) * sign(p.x - p.y);
}

float CalculateSDF(float2 UV)
{
    return HeartSDF_Custom(UV * (12 - _Size));
}
