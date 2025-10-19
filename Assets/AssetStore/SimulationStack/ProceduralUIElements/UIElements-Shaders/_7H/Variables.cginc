
float4 _ImageSizeRatio;
float _RadiusCenterPoint, _Arc, _Separation, _Thickness;
float _EnableRim, _RimWidth, _RimGamma, _EdgeBlur;
float _XOffset, _YOffset, _Rotation, _FillAmount;

float SDF = 0;

float ArcSDF(float2 p, float2 sc, float ra, float rb)
{
    // sc is the sin/cos of the arc's aperture
    p.x = abs(p.x);
    return ((sc.y * p.x > sc.x * p.y) ? length(p - sc * ra) : abs(length(p) - ra)) - rb;
}

float CalculateSDF(float2 UV)
{
    UV = RotateXY(UV - float2(_XOffset, _YOffset), _Rotation);
    float Arc = (_Arc / 180) * (3.1415 / 2.0);
    float SDF = 10.0;
    float SDF0 = length(UV) - _RadiusCenterPoint;
    UV.y -= _RadiusCenterPoint * 0.5;
    float SDF1 = ArcSDF(UV, float2(sin(Arc), cos(Arc)), _Separation, _Thickness);
    float SDF2 = ArcSDF(UV, float2(sin(Arc), cos(Arc)), _Separation * 2.0, _Thickness);
    float SDF3 = ArcSDF(UV, float2(sin(Arc), cos(Arc)), _Separation * 3.0, _Thickness);
    float SDF4 = ArcSDF(UV, float2(sin(Arc), cos(Arc)), _Separation * 4.0, _Thickness);
    float SDF5 = ArcSDF(UV, float2(sin(Arc), cos(Arc)), _Separation * 5.0, _Thickness);
    SDF = min(SDF, SDF0);
    SDF = _FillAmount >= 1 ? min(SDF, SDF1) : SDF;
    SDF = _FillAmount >= 2 ? min(SDF, SDF2) : SDF;
    SDF = _FillAmount >= 3 ? min(SDF, SDF3) : SDF;
    SDF = _FillAmount >= 4 ? min(SDF, SDF4) : SDF;
    SDF = _FillAmount >= 5 ? min(SDF, SDF5) : SDF;

    return SDF;
}
