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