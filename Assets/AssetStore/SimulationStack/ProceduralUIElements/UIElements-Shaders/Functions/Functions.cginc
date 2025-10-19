
float dot2(float2 v) { return dot(v, v); }

float RandomNumber(float2 p)
{
    p = frac(p * float2(234.34, 435.345));
    p += dot(p, p + 34.23);
    return frac(p.x * p.y);
}

float2 RotateXY(float2 UV, float Angle)
{
    float2 UVRotated = UV;
    Angle = Angle * (3.14 / 180);
    UVRotated.x = UV.x * cos(Angle) - UV.y * sin(Angle);
    UVRotated.y = UV.x * sin(Angle) + UV.y * cos(Angle);
    return UVRotated;
}