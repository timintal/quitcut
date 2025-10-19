float4 _ImageSizeRatio;

float _ShapeBlendMode;
float _Blend;

float _EnableRim;
float _RimWidth;
float _RimGamma;
float _EdgeBlur;

float _ChooseShapeA;
float _RadiusA, _WidthA, _HeightA, _CornerRoundnessA, _RotationA, _XOffsetA, _YOffsetA;
float _ChooseShapeB;
float _RadiusB, _WidthB, _HeightB, _CornerRoundnessB, _RotationB, _XOffsetB, _YOffsetB;


float CircleSDF(float2 UV, float Radius)
{
    return length(UV) - Radius;
}

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}


float SmoothIntersectSDF(float distA, float distB, float k)
{
    float h = clamp(0.5 - 0.5 * (distA - distB) / k, 0., 1.);
    return lerp(distA, distB, h) + k * h * (1. - h);
}

float SmoothUnionSDF(float distA, float distB, float k)
{
    float h = clamp(0.5 + 0.5 * (distA - distB) / k, 0., 1.);
    return lerp(distA, distB, h) - k * h * (1. - h);
}

float SmoothDifferenceSDF(float distA, float distB, float k)
{
    float h = clamp(0.5 - 0.5 * (distB + distA) / k, 0., 1.);
    return lerp(distA, -distB, h) + k * h * (1. - h);
}



float CalculateSDF(float2 UV)
{
    float ShapeASDF = 0;

    if (_ChooseShapeA == 0)
    {
        ShapeASDF = CircleSDF(UV - float2(_XOffsetA, _YOffsetA), _RadiusA);
    }
    else if (_ChooseShapeA == 1)
    {
        ShapeASDF = BoxSDF(RotateXY(UV - float2(_XOffsetA, _YOffsetA), _RotationA), float2(_WidthA, _HeightA)) - _CornerRoundnessA;
    }

    float ShapeBSDF = 0;

    if (_ChooseShapeB == 0)
    {
        ShapeBSDF = CircleSDF(UV - float2(_XOffsetB, _YOffsetB), _RadiusB);
    }
    else if (_ChooseShapeB == 1)
    {
        ShapeBSDF = BoxSDF(RotateXY(UV - float2(_XOffsetB, _YOffsetB), _RotationB), float2(_WidthB, _HeightB)) - _CornerRoundnessB;
    }

    float SDF = 0;

    if (_ShapeBlendMode == 0)
    {
        SDF = SmoothUnionSDF(ShapeASDF, ShapeBSDF, _Blend);
    }
    else if (_ShapeBlendMode == 1)
    {
        SDF = SmoothDifferenceSDF(ShapeASDF, ShapeBSDF, _Blend);
    }

    return SDF;
}


