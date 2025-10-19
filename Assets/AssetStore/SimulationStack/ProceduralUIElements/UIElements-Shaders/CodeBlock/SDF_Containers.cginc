
if (_MaskContainer == 0)
{
    SDF = length(UV) - _Radius;
}
else if (_MaskContainer == 1)
{
    #include "../CodeBlock/RectangleCodeBlock.cginc"
    SDF = RoundBoxSDF(UV, float2(_Width, _Height), _CornerRoundness);
}
else if (_MaskContainer == 2)
{
    SDF = StarSDF(UV, _PolygonSize, _PolygonTurns, _PolygonEdgeAngle) - _CornerRoundness;
}
else if (_MaskContainer == 3)
{
    SDF = HeartSDF_Custom(UV * (12 - _HeartSize));
}
