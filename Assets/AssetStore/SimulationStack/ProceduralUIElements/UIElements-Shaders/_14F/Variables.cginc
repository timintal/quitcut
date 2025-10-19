
float4 _ImageSizeRatio;
float _MaskContainer;
float _CircleRadius;

float _ChooseDimensionParameters;
float _Width, _Height;
float _WidthMargin, _HeightMargin;

float _CornerRoundness;
float _ContainerEdgeBlur;
float _GridSize;
float _LineWidth;
float _Blur;
float _Gamma;
float _Opacity;
float _Rotate;
float _Twist;


float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}

float RoundBoxSDF(float2 UV, float2 Dimension, float Radius)
{
    return BoxSDF(UV, Dimension) - Radius;
}
