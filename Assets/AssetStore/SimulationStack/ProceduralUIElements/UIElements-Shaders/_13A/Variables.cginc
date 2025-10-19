
float4 _ImageSizeRatio;
float _NoOfCells;
float _FillAmount;
float _DotShape;

float _Radius;
float _Width;
float _Height;
float _CornerRoundness;
float _Rotation;

float _EnableRim, _RimWidth, _RimGamma;

float _AnimatePosition, _AnimateScale, _AnimateColorAlpha, _AnimationScale, _AnimationSpeed;

float _EdgeBlur;
float _ApplyColorModeToEachCell;

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}

float RoundBoxSDF(float2 UV, float2 Dimension, float Radius)
{
    return BoxSDF(UV, Dimension) - Radius;
}
