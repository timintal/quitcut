
float _ChooseReflectionShape;
float _CircleRadius, _CircleBlur, _CircleXOffset, _CircleYOffset, _CircleYScale, _CircleYBend, _CircleRotation;
float _ChooseLineMode;
float _LineWidth, _LineWidthA, _LineWidthB, _LinesSeparation, _LineEdgeBlur, _Rotate, _LineOffset, _Inc;
float _EnableBend, _Bend, _Curvature;
float _EnableAnimation, _MoveSpeed, _Frequency;
fixed4 _Color;
float _Opacity, _EnableAlphaGradient, _AlphaGradientAngle, _AlphaGradientStep, _AlphaGradientScale, _AlphaGradientGamma;

float BoxSDF(float2 UV, float2 Dimension)
{
    float2 d = abs(UV) - Dimension;
    return length(max(d, 0.0)) + min(max(d.x, d.y), 0.0);
}
